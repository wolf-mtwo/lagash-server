# lagash-server

## data base installation

Projects runs with entity framework.

## services resume

Base URL **"http://localhost:8080/api"**

Header **Content-Type: application/json**

Header **x-access-token:||token||**

## public

POST **{{base_url}}/p1/users** // object
POST **{{base_url}}/p1/login** // object

## private

POST **{{base_url}}/p1/logout** // object
GET **{{base_url}}/users** // array
GET **{{base_url}}/users** // array
GET **{{base_url}}/users/:id** // object
DELETE **{{base_url}}/users/:id** // object
PUT **{{base_url}}/users/:id** __**object**__
GET **{{base_url}}/rest/session/login**
GET **{{base_url}}/rest/session/login**


## especial

**Content-Type: multipart/form-data**

POST **{{base_url}}/p1/files** *excel*
Form ['file_name']
