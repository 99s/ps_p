# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class ActionTbl(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    action_taken_by = models.TextField(db_column='Action_Taken_by', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    which_action_taken = models.TextField(db_column='Which_Action_Taken', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    time_of_action = models.DateTimeField(db_column='Time_of_Action', blank=True, null=True)  # Field name made lowercase.
    dr_no = models.TextField(db_column='DR_No', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    ipc_crpc_section = models.TextField(db_column='IPC_CRPC_section', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    evidence_doc_fk = models.BigIntegerField(db_column='Evidence_Doc_fk', blank=True, null=True)  # Field name made lowercase.
    autharity_name = models.TextField(db_column='Autharity_Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    complaint_id_fk = models.BigIntegerField(db_column='Complaint_ID_fk', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Action_tbl'


class AdditionaldataTbl(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    name = models.TextField(db_column='Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    description = models.TextField(db_column='Description', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    data = models.TextField(db_column='Data', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'AdditionalData_tbl'


class ComplainTable(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    gd_no = models.TextField(db_column='GD_no', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    complain_no = models.TextField(db_column='Complain_no', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    isgd = models.BooleanField(db_column='isGD')  # Field name made lowercase.
    complain_date_time = models.TextField(db_column='Complain_Date_Time')  # Field name made lowercase. This field type is a guess.
    complainant_name = models.TextField(db_column='Complainant_Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    victim_name = models.TextField(db_column='Victim_Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    complainant_address = models.TextField(db_column='Complainant_Address', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    mobile_no = models.TextField(db_column='Mobile_No', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    email_id = models.TextField(db_column='Email_Id', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    complain_nature = models.TextField(db_column='Complain_Nature', db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    gist_of_the_complain = models.TextField(db_column='Gist_of_the_Complain', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    accused_details = models.TextField(db_column='Accused_details', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    date_time_of_incident = models.TextField(db_column='Date_Time_of_Incident', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    evidence_doc_fk = models.TextField(db_column='Evidence_Doc_fk', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Complain_Table'


class DocsTbl(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    doc_date = models.TextField(db_column='Doc_Date', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    doc_name = models.TextField(db_column='Doc_Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    doc_path = models.TextField(db_column='Doc_Path', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Docs_tbl'


class ReplyTbl(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    reply_date = models.DateTimeField(db_column='Reply_Date', blank=True, null=True)  # Field name made lowercase.
    case_reference_no = models.TextField(db_column='Case_Reference_No', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    authority_name = models.TextField(db_column='Authority_Name', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    authority_address = models.TextField(db_column='Authority_Address', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    reply_gist = models.TextField(db_column='Reply_Gist', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    dr_no = models.TextField(db_column='DR_No', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    evidence_doc_id_fk = models.BigIntegerField(db_column='Evidence_Doc_id_fk', blank=True, null=True)  # Field name made lowercase.
    complaint_id_fk = models.BigIntegerField(db_column='Complaint_ID_fk', blank=True, null=True)  # Field name made lowercase.
    suspect_status = models.TextField(db_column='Suspect_Status', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    court_order = models.TextField(db_column='Court_Order', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    status = models.TextField(db_column='Status', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    court_name_address = models.TextField(db_column='Court_Name_Address', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    order_no = models.TextField(db_column='Order_No', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    order_date_time = models.DateTimeField(db_column='Order_Date_Time', blank=True, null=True)  # Field name made lowercase.
    order_gist_court = models.TextField(db_column='Order_Gist_Court', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    order_copy_doc_fk = models.BigIntegerField(db_column='Order_Copy_doc_fk', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Reply_tbl'


class Usertable(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    usertype_fk = models.BigIntegerField(db_column='userType_fk', blank=True, null=True)  # Field name made lowercase.
    name = models.CharField(db_column='Name', max_length=100, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    description = models.CharField(db_column='Description', max_length=200, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    passwordhash = models.TextField(db_column='PasswordHash', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    loginname = models.TextField(db_column='loginName', db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'userTable'


class UsertypeTbl(models.Model):
    id = models.BigAutoField(db_column='ID', primary_key=True)  # Field name made lowercase.
    name = models.CharField(db_column='Name', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    description = models.CharField(db_column='Description', max_length=50, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'userType_tbl'
