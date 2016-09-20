import re, urllib, urllib2, importlib

from config import OP_DESC_PATTERN
from config import OP_PATTERN
from config import IP_PATTERN
from config import HOSTFAIL_PATTERN
from config import FAILBACK_PATTERN
from config import VMRULES
from config import HOSTRULES

class ResultAnalyzer(object):
    def __init__(self, resultfile_http_folder):
        self.op_prog = re.compile(OP_PATTERN) 
        self.op_desc_prog = re.compile(OP_DESC_PATTERN)
        self.host_fail_prog = re.compile(HOSTFAIL_PATTERN)
        self.host_failback_prog = re.compile(FAILBACK_PATTERN)
        self.ip_prog = re.compile(IP_PATTERN)
        self.resultfile_http_folder = resultfile_http_folder

    def get_file(self, filename):
        try:
            urllib.urlretrieve(self.resultfile_http_folder+'/'+filename, "tmp/download.log")
        except urllib2.HTTPError, err:
            raise err

    def parse_vmstats(self):
        parse_result = {}
        for rule in VMRULES:        
#            self.get_file(rule['filename'])
            resultfile = open('../Test_File/Test_Report.html')
            if 'handler' in rule.keys():
                ## Do something special
                handler = getattr(importlib.import_module("handler"), rule['handler'])
                handler_instance = handler(resultfile)
                parse_result[rule['name']] = handler_instance.parse(rule)
            resultfile.close()
        #print parse_result
        self.vm_parse_result = parse_result

    def generate_vmstat_report(self):
        i=0
        vmstat_htmltext = ''
        for rule in VMRULES:
            ## generate style change when start a new row
            if (i % 2 == 0):
                vmstat_htmltext += '<tr>'
            else:
                vmstat_htmltext += '<tr class=\"even\">'

            i=i+1
            
            if rule['name'] not in self.vm_parse_result.keys(): ##PASS!
                vmstat_htmltext+= '<td>'+rule['name']+'</td>'+'<td>PASS</td><td>'+rule['pass_justification']+'</td><td>&nbsp;</td></tr>'
                continue

            detected_vm_num = len(self.vm_parse_result[rule['name']])

            if (detected_vm_num > int(rule['threshold'])): ##FAIL
                vmstat_htmltext+='<td>'+rule['name']+'</td>'+'<td>FAIL</td><td>'+rule['fail_justification'] % (rule['threshold'],str(detected_vm_num)) +'</td><td>&nbsp;</td></tr>'
                continue

            if (detected_vm_num <= int(rule['threshold'])): ##CPASS
                vmstat_htmltext+='<td>'+rule['name']+'</td>'+'<td>CPass</td><td>'+rule['cpass_justification'] % (rule['threshold'],str(detected_vm_num)) +'</td><td>&nbsp;</td></tr>'

        self.vmstat_htmltext = vmstat_htmltext
        print vmstat_htmltext

    def parse_hoststats(self):
        parse_result = {}
        for rule in HOSTRULES:
            indent_fail_hostlist = []
            host_oplist_mapping = {}
            found_op_list = []
            rule_prog = re.compile(rule['pattern'])
            self.get_file(rule['filename'])
            resultfile = open('tmp/download.log')
            indent_fail_hostlist = []
            rule_pattern_prog = re.compile(rule['pattern'])
            for line in resultfile:
                op_match = self.op_prog.search(line)
                opd_match = self.op_desc_prog.match(line)
                if(op_match):
                    cur_opid = op_match.group(0)[:-1]
                    cur_op_line = line
                    continue
                if(opd_match):
                    ## find all host ips in description
                    hostips_match = self.ip_prog.findall(opd_match.group(0))
                    if hostips_match and self.host_fail_prog.match(cur_op_line):
                        for hostip in hostips_match:
                            indent_fail_hostlist.append(hostip)
                    if hostips_match and self.host_failback_prog.match(cur_op_line):
                        for hostip in hostips_match:
                            indent_fail_hostlist.remove(hostip)
                rule_match = rule_pattern_prog.match(line)
                if( rule_match and 'FailbackOp' not in cur_op_line):
                    nonresp_host_match = self.ip_prog.search(line)
                    if nonresp_host_match:
                        nonresp_host = nonresp_host_match.group(0)
                        if nonresp_host in indent_fail_hostlist:
                            print "Indent host failure found:" + nonresp_host + " in " + cur_opid
                        else:
                            if cur_opid not in found_op_list:
                                found_op_list.append(cur_opid)
                                host_oplist_mapping[nonresp_host] = found_op_list
                                parse_result[rule['name']] = host_oplist_mapping
        self.host_parse_result = parse_result
        print self.host_parse_result

    def generate_hoststat_report(self):
        i=0
        hoststat_htmltext = ''
        for rule in HOSTRULES:
            ## generate style change when start a new row
            if (i % 2 == 0):
                hoststat_htmltext += '<tr>'
            else:
                hoststat_htmltext += '<tr class=\"even\">'

            i=i+1
            
            if rule['name'] not in self.host_parse_result.keys(): ##PASS!
                hoststat_htmltext+= '<td>'+rule['name']+'</td>'+'<td>PASS</td><td>'+rule['pass_justification']+'</td><td>&nbsp;</td></tr>'
                continue

            detected_host_num = len(self.host_parse_result[rule['name']])

            if (detected_host_num > int(rule['threshold'])): ##FAIL
                hoststat_htmltext+='<td>'+rule['name']+'</td>'+'<td>FAIL</td><td>'+rule['fail_justification'] % (rule['threshold'],str(detected_host_num)) +'</td><td>&nbsp;</td></tr>'
                continue

            if (detected_host_num <= int(rule['threshold'] and detected_host_num > 0)): ##CPASS
                hoststat_htmltext+='<td>'+rule['name']+'</td>'+'<td>CPass</td><td>'+rule['cpass_justification'] % (rule['threshold'],str(detected_host_num)) +'</td><td>&nbsp;</td></tr>'

        self.hoststat_htmltext = hoststat_htmltext
        print self.hoststat_htmltext
                
                
            

#result_analyzer = ResultAnalyzer("http://st-cluster9-vmuf.eng.vmware.com/stsds_4tb_1/st-cluster9/VSANClusterSplitMerge-20160904-033155/VSANClusterSplitMerge-20160904-103155/VSANClusterSplitMerge/")
result_analyzer = ResultAnalyzer("http://pa-dbc1133.eng.vmware.com/edwardx/")

result_analyzer.parse_vmstats()
#result_analyzer.generate_vmstat_report()
#result_analyzer.parse_hoststats()
#result_analyzer.generate_hoststat_report()

            
    
