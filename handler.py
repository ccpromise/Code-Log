import re


from config import OP_DESC_PATTERN
from config import OP_PATTERN
from config import IP_PATTERN
from config import HOSTFAIL_PATTERN
from config import FAILBACK_PATTERN
from config import VMRULES
from config import HOSTRULES


class Handler(object):
    def __init__(self, logfile):
        self.log_file = logfile
        self.op_prog = re.compile(OP_PATTERN) 
        self.op_desc_prog = re.compile(OP_DESC_PATTERN)
        self.host_fail_prog = re.compile(HOSTFAIL_PATTERN)
        self.host_failback_prog = re.compile(FAILBACK_PATTERN)
        self.ip_prog = re.compile(IP_PATTERN)
        
    def parse(self):
        pass


class DefaultVmstatsHandler(Handler):
    def parse(self, rule):
        rule_prog = re.compile(rule['pattern'])
        found_op_list = []
        vm_oplist_mapping = {}
        for line in self.log_file:
            op_match = self.op_prog.search(line)
            if(op_match):
                cur_opid = op_match.group(0)[:-1]
                continue
            rule_match = rule_prog.search(line)
            if(rule_match):
                if cur_opid not in found_op_list:
                    found_op_list.append(cur_opid)
                entry = rule_match.group(0).split()
                vmname = entry[0].strip()
                vm_oplist_mapping[vmname] = found_op_list
        return vm_oplist_mapping
            
            
class VmProfileNAHandler(Handler):
    def parse(self, rule):
        print rule['pattern']
        rule_prog = re.compile(rule['pattern'])
        found_op_list = []
        vm_oplist_mapping = {}
        count = 0
        for line in self.log_file:
            op_match = self.op_prog.search(line)
            if(op_match):
                cur_opid = op_match.group(0)[:-1]
                continue
            rule_match = rule_prog.match(line)
            if(rule_match and count == 0):
                if cur_opid not in found_op_list:
                    found_op_list.append(cur_opid)
                count = int(rule_match.group(0).split()[0])
                continue
            if count > 0:
                vmname = line[:-1]
                if vmname not in vm_oplist_mapping.keys():
                    vm_oplist_mapping[vmname] = found_op_list
                count = count - 1
                continue
        return vm_oplist_mapping

class VmHAProtectedHanlder(Handler):
    def parse(self, rule):
        rule_prog = re.complie(rule['pattern'])
        found_op_list = []
        vm_oplist_mapping = {}
        N = len(self.log_file)
        i = 0
        while(i < N):
            line = self.log_file[i]
            i += 1
            op_match = self.op_prog.search(line)
            if(op_match):
                cur_opid = op_match.group(0)[:-1]
                continue
            rule_match = rule_prog.search(line)
            if(rule_match):
                info = re.split('\W+', rule_match.group(0))
                passVM = int(info[0])
                totalVM = int(info[1])
                if(passVM < totalVM):
                    if(cur_opid not in found_op_list):
                        found_op_list.append(cur_opid)
                    line = self.log_file[i]
                    ip_match = self.ip_prog.search(line)
                    while(ip_match):
                        ip = ip_match.group(0)[:-1] # match until space
                        vm_oplist_mapping[ip] = found_op_list
                        i += 1
                        line = self.log_file[i]
                        ip_match = self.ip_prog_search(line)
        return vm_oplist_mapping
    #problem is : the ip is not vm, maybe a cluster. You cannot count the number.
