from rest_framework import serializers
from adminpanel.models import ActionTbl,AdditionaldataTbl,ComplainTable,DocsTbl,ReplyTbl,Usertable,UsertypeTbl


class ActionTblSerializer(serializers.ModelSerializer):
    class Meta:
        model=ActionTbl 
        fields=('id','action_taken_by','which_action_taken','time_of_action','dr_no','ipc_crpc_section'
                ,'evidence_doc_fk','autharity_name','complaint_id_fk')

class AdditionaldataTblSerializer(serializers.ModelSerializer):
    class Meta:
        model=AdditionaldataTbl 
        fields=('id','name','description','data')
        
class ComplainTableSerializer(serializers.ModelSerializer):
    class Meta:
        model=ComplainTable 
        fields=('id','gd_no','complain_no','isgd','complain_date_time','complainant_name','victim_name',
                'complainant_address','mobile_no','email_id','complain_nature',
                'gist_of_the_complain','accused_details','date_time_of_incident','evidence_doc_fk')
        
class DocsTblSerializer(serializers.ModelSerializer):
    class Meta:
        model=DocsTbl 
        fields=('id','doc_date','doc_name','doc_path')
        
class ReplyTblSerializer(serializers.ModelSerializer):
    class Meta:
        model=ReplyTbl 
        fields=('id','reply_date','case_reference_no','authority_name','authority_address','reply_gist','dr_no',
                'evidence_doc_id_fk','complaint_id_fk','suspect_status','court_order',
                'status','court_name_address','order_no','order_date_time','order_gist_court','order_copy_doc_fk')
        
class UsertableSerializer(serializers.ModelSerializer):
    class Meta:
        model=Usertable 
        fields=('id','usertype_fk','name','description','passwordhash','loginname')
        
class UsertypeTblSerializer(serializers.ModelSerializer):
    class Meta:
        model=UsertypeTbl 
        fields=('id','name','description')