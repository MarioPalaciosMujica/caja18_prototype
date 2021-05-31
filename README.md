# Caja18 - Prototype

Este Proyecto consiste en el ejemplo de una arquitectura de microservicios; esta desarrollado con .Net Core 3.1, e incluye las siguientes APIs:

1. Identity Server: Servicio Identity Server 4 para la Autentificación y Autorización de usuarios.
2. WebGateway : ApiGateway para los microservicios.
3. Catalog.API: Microservicio que contiene lógica de Productos.
4. Payments.API: Microservicio que contiene lógica de Formas de Pago.
5. Orders.API: Microservicio que contiene lógica de Ordenes de Compras realizadas.
6. Purchase.Aggregator: Microservicio Aggregation para realizar una compra. Esta api es cliente de Catalog.API, Payments.API y Orders.API.

Además, se añade el archivo: "caja18_prototype.postman_collection.json" <br>
Para realizar pruebas del funcionamiento de toda la arquitectura.
Dicho archivo se debe importar a Postman.

Para la utlización de los diferentes endpoints, se debe crear un Token con "IS4 / Token".
Dicho Token se debe pasar como parametro de "Authentification" en el header de todos los requests de cada endpoint, ya que todos estos requieren autentificación y autorización.
