pip install django
pip install mssql-connector-python
pip install mssql-django

django-admin startproject website
python manage.py runserver
django-admin startapp signup
django-admin startapp login

settings.py > installed-apps > signup
settings.py > installed-apps > login

settings.py > 


in template folder create signup.html and login.html
then in signup > views.py > signupaction
then in login > views.py > loginaction

then in urls.py -- > from signup.views import signupaction /&/ from login.views import loginaction
then in urls.py -- > urlpatterns[path('signup/',signupaction)] 

pip3 install djangorestframework
pip install django-cors-headers
pip3 install django-cors-headers


$ python manage.py inspectdb
$ python manage.py inspectdb > models.py