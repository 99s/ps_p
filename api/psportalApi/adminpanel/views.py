from django.shortcuts import render

from django.views.decorators.csrf import csrf_exempt
from rest_framework.parsers import JSONParser
from django.http.response import JsonResponse

from adminpanel.models import ActionTbl,AdditionaldataTbl,ComplainTable,DocsTbl,ReplyTbl,Usertable,UsertypeTbl
from serializer import ActionTblSerializer,AdditionaldataTblSerializer,ComplainTableSerializer,DocsTblSerializer,ReplyTblSerializer,UsertableSerializer,UsertypeTblSerializer

from django.core.files.storage import default_storage

# Create your views here.

@csrf_exempt
def AdditionaldataTblApi(request,id=0):
    if request.method=='GET':
        additionaldata = AdditionaldataTbl.objects.all()
        additionaldata_serializer=AdditionaldataTblSerializer(additionaldata,many=True)
        return JsonResponse(additionaldata_serializer.data,safe=False)
    elif request.method=='POST':
        additionaldata_data=JSONParser().parse(request)
        additionaldata_serializer=AdditionaldataTblSerializer(data=additionaldata_data)
        if additionaldata_serializer.is_valid():
            additionaldata_serializer.save()
            return JsonResponse("Added Successfully additionaldata",safe=False)
        return JsonResponse("Failed to Add additionaldata",safe=False)
    elif request.method=='PUT':
        additionaldata_data=JSONParser().parse(request)
        additionaldata=AdditionaldataTbl.objects.get(DepartmentId=additionaldata_data['id'])
        additionaldata_serializer=AdditionaldataTblSerializer(additionaldata,data=additionaldata_data)
        if additionaldata_serializer.is_valid():
            additionaldata_serializer.save()
            return JsonResponse("Updated Successfully additionaldata",safe=False)
        return JsonResponse("Failed to Update additionaldata")
    elif request.method=='DELETE':
        additionaldata=AdditionaldataTbl.objects.get(DepartmentId=id)
        additionaldata.delete()
        return JsonResponse("Deleted Successfully additionaldata",safe=False)



@csrf_exempt
def SaveFile(request):
    file=request.FILES['file']
    file_name=default_storage.save(file.name,file)
    return JsonResponse(file_name,safe=False)
# Create your views here.
def adminaction(request):
    return None;