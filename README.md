# lagash-server

## data base installation

Projects runs with entity framework.

## services resume

Base URL **"http://localhost:8080/api"**

Header **Content-Type: application/json**

Header **x-access-token:||token||**

## public

POST **/p1/login** _OBJECT_

## private


POST **/v1/logout** _OBJECT_

GET **/v1/users** _ARRAY_

POST **/v1/users** _OBJECT_

GET **/v1/users/:user_id** _OBJECT_

DELETE **/v1/users/:user_id** _OBJECT_

PUT **/v1/users/:user_id** _OBJECT_

GET **/v1/catalog/page/:page/limit/:limit** _ARRAY_ _REVERSE_

POST **/v1/catalogs** _OBJECT_

GET **/v1/catalogs/:catalog_id** _OBJECT_

DELETE **/v1/catalogs/:catalog_id** _OBJECT_

PUT **/v1/catalogs/:catalog_id** _OBJECT_

GET **/v1/catalogs/:catalog_id/books** _OBJECT_

POST **/v1/catalogs/:catalog_id/books** _ARRAY_

POST **/v1/catalogs/:catalog_id/books/page/:page/limit/:limit** _ARRAY_

GET **/v1/books/page/:page/limit/:limit** _ARRAY_ _REVERSE_

[most be defined] POST **/v1/books** _OBJECT_

GET **/v1/books/:book_id** _OBJECT_

DELETE **/v1/books/:book_id** _OBJECT_

PUT **/v1/books/:book_id** _OBJECT_

POST **/v1/books/:book_id/specimens** _OBJECT_

GET **/v1/books/:book_id/specimens** _ARRAY_

GET **/v1/specimens/:specimen_id** _OBJECT_

DELETE **/v1/specimens/:specimen_id** _OBJECT_

PUT **/v1/specimens/:specimen_id** _OBJECT_

GET **/v1/newspapers** _ARRAY_

POST **/v1/newspapers** _OBJECT_

GET **/v1/newspapers/:newspaper_id** _OBJECT_

PUT **/v1/newspapers/:newspaper_id** _OBJECT_

DELETE **/v1/newspapers/:newspaper_id** _OBJECT_

GET **/v1/newspapers/:newspaper_id/journals** _ARRAY_

POST **/v1/newspapers/:newspaper_id/journals** _OBJECT_

GET **/v1/journals/:journal_id** _OBJECT_

PUT **/v1/journals/:journal_id** _OBJECT_

DELETE **/v1/journals/:journal_id** _OBJECT_

## especial

**Content-Type: multipart/form-data**

POST **/p1/files** *excel*
Form ['file_name']
