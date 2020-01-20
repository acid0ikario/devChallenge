Pasos para levantar la solucion
- correr el script de creacion de base de datos (en caso de error se incluye archivo .bak para restore de la base de datos)
- actualizar connectionString en appSetting.json del proyecto WebApi para apuntar al servidor, o dejar "." para una base de datos local.
- ejecutar el proyecto WebApi
- ejecutar el proyecto WebApp desde visual studio: click derecho / debug / start new intance


Casos de pruebas POSTMAN

Tokens de usuario:

admin: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwicm9sSWQiOiJBRE0iLCJleHAiOjE1Nzk1NzY1MzAsImlzcyI6InBnczMwLmNvbSIsImF1ZCI6InBnczMwLmNvbSJ9.dCDy_FU4lY85aNtvmhAfNzfYd8P_AXIl2M63IM4IJkM"
pgs360: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InBnczM2MCIsInJvbElkIjoiQ1RNIiwiZXhwIjoxNTc5NTc2NTQ5LCJpc3MiOiJwZ3MzMC5jb20iLCJhdWQiOiJwZ3MzMC5jb20ifQ.hh4SNe_KspEE3YeSo_tzO0gERYIPh785GzsPVwjMxzY"
customer: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImN1c3RvbWVyIiwicm9sSWQiOiJDVE0iLCJleHAiOjE1Nzk1NzY1NjEsImlzcyI6InBnczMwLmNvbSIsImF1ZCI6InBnczMwLmNvbSJ9.pl81mwNYGPfNEcHkT8s4HEmSWZux_do9QtB0FfFjKFg"

Authenticate user:
https://localhost:44386/api/Login/Authenticate
request body POST:
{
	"userId": "admin",
	"password": "123456"
}

Este action devolvera un token para que se tiene utilizar para el resto de las peticiones.
Configurar POSTMAN en Authorization como type Bearer Token y pegar el token generado

GetListItems
GET
https://localhost:44386/api/Inventory/GetListItems
busqueda por sku
https://localhost:44386/api/Inventory/GetListItems?sku=1


GetAvalibleSku
GET
https://localhost:44386/api/Inventory/GetAvalibleSku


AddItem
https://localhost:44386/api/Inventory/addItem
request body POST:
{
    "qty": "5",
    "description": "Decription firts item",
    "price": "49.99"
}

updateItem
https://localhost:44386/api/Inventory/updateItem
request body POST:
{
    "sku": "1",
    "qty": "5",
    "description": "Decription test update firts item",
    "price": "49.99"
}

createOrder
https://localhost:44386/api/Orders/CreateOrder
request body POST:
 {
        "sku": 1,
        "shippingAddress":"Bulevar Sergio Viera De Mello 243, San Salvador",
        "qty": 5
    }

cancelOrder
https://localhost:44386/api/Orders/CancelOrder
request body POST:
 {
         "orderId": 3,
         "userId": "admin"
 }


