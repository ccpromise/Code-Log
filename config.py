OP_DESC_PATTERN = '.+op\d\.\d+\-d.+'
OP_PATTERN = 'op\d\.\d+\"'
HOSTFAIL_PATTERN = '.+H.+FailureOp.+'
FAILBACK_PATTERN = '.+FailbackOp.+'
IP_PATTERN = '\d+\.\d+\.\d+\.\d+'

# vm status: accessible, compliant, powered on, guest tool running, guest running, connected, orphaned, valid, NA
# TODO: renamed, duplicate, HA protected
#
VMRULES=[{
    "name":"All vms are accessible during test",
    "pattern":"\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+INACCESSIBLE",
    "filename":"TestResult.html",
    "pass_justification":"No inaccessible VM detected",
    "fail_justification":"Expect %s vms inaccessible allowed. Actual: %s",
    "fail_details":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s vms inaccessible allowed. Actual: %s",
    "cpass_details":"vm name: %s, found in op %s",
    "threshold":"0",
    "handler":"DefaultVmstatsHandler"
    },{
    "name":"All vms are compliant",
    "pattern":".*overallComplianceStatus\:nonCompliant.*",
    "filename":"TestResult.html",
    "pass_justification":"All vms are compliant",
    "fail_justification":"Expect %s vms noncompliant allowed. Actual: %s",
    "cpass_justification":"Expect %s vms noncomplant allowed. Actual: %s",
    "threshold":"10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name": "All vms are powered on during test",
    "pattern": "\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+POWERED_OFF",
    "filename":"HostFailures.html",
    "pass_justification":"No powered_off VM detected",
    "fail_justification":"Expect %s vms powered_off allowed. Actual: %s",
    "fail_detail":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s vms powered_off allowed. Actual: %s",
    "cpass_detail":"vm name: %s, found in op %s",
    "threshold":"10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name": "All vms' guest tools are healthy",
    "pattern": "\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+guestToolsNotRunning",
    "filename":"TestResult.html",
    "pass_justification":"All guest tools are running.",
    "fail_justification":"Expect %s guest tools not running allowed. Actual: %s",
    "fail_detail":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s guest tools not running allowed. Actual: %s",
    "cpass_detail": "vm name: %s, found in op %s",
    "threshold": "10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name":"All vms storage profiles are available",
    "pattern":".*vms\s+are\s+NA.*",
    "filename":"TestResult.html",
    "pass_justification":"All vms storage profiles are available",
    "fail_justification":"Expect %s vms NA allowed. Actual: %s",
    "cpass_justification":"Expect %s vms NA allowed. Actual: %s",
    "threshold":"2",
    "handler":"VmProfileNAHandler"# 2 batches
    },{
    "name": "All vms' guests are healthy",
    "pattern": "\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+(notRunning|unknown)",
    "filename":"TestResult.html",
    "pass_justification":"All guests are running.",
    "fail_justification":"Expect %s guests not running or unknown allowed. Actual: %s",
    "fail_detail":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s guests not running or unknown allowed. Actual: %s",
    "cpass_detail": "vm name: %s, found in op %s",
    "threshold": "10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name":"All vms are connected during test",
    "pattern":"\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+DISCONNECTED",
    "filename":"TestResult.html",
    "pass_justification":"No disconnected VM detected",
    "fail_justification":"Expect %s vms disconnected allowed. Actual: %s",
    "fail_details":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s vms disconnected allowed. Actual: %s",
    "cpass_details":"vm name: %s, found in op %s",
    "threshold":"10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name":"All vms are not orphaned during test",
    "pattern":"\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+ORPHANED",
    "filename":"TestResult.html",
    "pass_justification":"No orphaned VM detected",
    "fail_justification":"Expect %s vms orphaned allowed. Actual: %s",
    "fail_details":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s vms orphaned allowed. Actual: %s",
    "cpass_details":"vm name: %s, found in op %s",
    "threshold":"10",
    "handler":"DefaultVmstatsHandler"
    },{
    "name":"All vms are valid during test",
    "pattern":"\d+\.\d+\.\d+\.\d+\-vsanDatastore.+\s+INVALID",
    "filename":"TestResult.html",
    "pass_justification":"No invalid VM detected",
    "fail_justification":"Expect %s vms invalid allowed. Actual: %s",
    "fail_details":"vm name: %s, found in op %s",
    "cpass_justification":"Expect %s vms invalid allowed. Actual: %s",
    "cpass_details":"vm name: %s, found in op %s",
    "threshold":"10",
    "handler":"DefaultVmstatsHandler"
    },
]

HOSTRULES=[{
    "name":"All hosts responsive except indent host failure during test",
    "pattern":".*\d+\.\d+\.\d+\.\d+\s+NOT_RESPONDING.*",
    "filename":"TestResult.html",
    "pass_justification":"No non-responsive host detected",
    "fail_justification":"Expect %s hosts non-responsive allowed, Actual: %s",
    "fail_details":"host ip: %s, found in op %s",
    "cpass_justification":"Expect %s hosts non-responsive allowed, Actual: %s",
    "cpass_details":"host ip: %s, found in op %s",
    "threshold":"0"
    },
]
