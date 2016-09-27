# lagash-server

## data base installation

Projects runs with entity framework.

## services resume

Base URL **"http://localhost:8080/api"**

Header **Content-Type: application/json**

Header **x-access-token:||token||**

## public

POST **/p1/users** __OBJECT__

POST **/p1/login** __OBJECT__

## private

POST **/p1/logout** __OBJECT__

GET **/v1/users** __ARRAY__

GET **/v1/users/:id** __OBJECT__

DELETE **/v1/users/:id** __OBJECT__

PUT **/v1/users/:id** __OBJECT__

## especial

**Content-Type: multipart/form-data**

POST **/p1/files** *excel*
Form ['file_name']
