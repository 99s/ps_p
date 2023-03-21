from django.urls import include, re_path
from adminpanel import views

from django.conf.urls.static import static
from django.conf import settings

urlpatterns=[
    re_path(r'^additionaldataapi$',views.AdditionaldataTblApi),
    re_path(r'^additionaldataapi/([0-9]+)$',views.AdditionaldataTblApi),

    re_path(r'^employee/savefile',views.SaveFile)
]+static(settings.MEDIA_URL,document_root=settings.MEDIA_ROOT)