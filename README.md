# lagash-server

## data base installation

Projects runs with entity framework.

## services resume

Base URL **"http://localhost:8080/api"**

Header **Content-Type: application/json**

Header **x-access-token:||token||**

## public

POST **/p1/users** _OBJECT_

POST **/p1/login** _OBJECT_

## private

POST **/p1/logout** _OBJECT_

GET **/v1/users** _ARRAY_

GET **/v1/users/:id** _OBJECT_

DELETE **/v1/users/:id** _OBJECT_

PUT **/v1/users/:id** _OBJECT_

## especial

**Content-Type: multipart/form-data**

POST **/p1/files** *excel*
Form ['file_name']
