# lagash-server

## data base installation

Projects runs with entity framework.

## services resume

Base URL **"http://localhost:8080/api"**

Header **Content-Type: application/json**

Header **x-access-token:||token||**

## public

POST **/p1/users** __**OBJECT**__

POST **/p1/login** __**OBJECT**__

## private

POST **/p1/logout** __**OBJECT**__

GET **/v1/users** __**ARRAY**__

GET **/v1/users/:id** __**OBJECT**__

DELETE **/v1/users/:id** __**OBJECT**__

PUT **/v1/users/:id** __**OBJECT**__

## especial

**Content-Type: multipart/form-data**

POST **/p1/files** *excel*
Form ['file_name']
