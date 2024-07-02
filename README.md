# Documentación Prueba Técnica Inalambria

## Descripción
 En esta prueba se solicitaba crear una API para convertir en su respectivo valor texto/lecutra al ingresar un número en el rango de 0 a 999.999.999.999.
 Así mismo, implementar un método de autenticación a elegir por el desarrollador, se opto por el ***Bearer Token***, 
 implementando un API para obtener un ***Token*** de validacíon con datos como ***Nombre*** y ***Correo***.

## Hosting o Despliegue
 Se desplego la solución de la prueba técnica en `Somee`.
 - **Host URL:** `http://www.inalambriatest.somee.com`.
Mediante esta **URL** y los **PATH** de los servicios podremos hacer uso de ellos.

## Requerimientos Previos
 Se debe obtener el Token de autorización previamente.
 - **Bearer Token URL:** `/api/Token`.
 - **Método HTTP:** `POST`

### Headers Requeridos
- `Content-Type`: `application/json`

### Parámetros de Entrada:
 - `Name` (obligatorio): Nombre del usuario a usar el servicio. Tipo: `string`.
 - `Email` (obligatorio): Email del usuario a usar el servicio. Tipo: `string`.
### Parámetros en el Cuerpo de la Solicitud (Request Body):
 ```json
 {
    "Name": "string",
    "Email": "example@email.com"
 }
 ```
### Ejemplo de Solicitud:
```bash
curl --location 'http://www.inalambriatest.somee.com/api/Token' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "Camilo",
    "Email": "camonayc@98gmail.com"
}'
```
### Respuesta del Endpoint (Response):
**Formato de la respuesta:** `application/json`.
#### Ejemplo de Respuesta Exitosa:
 ```json
{
    "statusCode": 200,
    "isSuccess": true,
    "message": "Conversión exitosa",
    "data": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L..."
}
 ```

### Ejemplo de Solicitud con Error:
```bash
curl --location 'http://www.inalambriatest.somee.com/api/Token' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "",
    "Email": "camonayc@98gmail.com"
}'
```
#### Ejemplo de Respuesta de Error:
 ```json
{
    "statusCode": 400,
    "isSuccess": false,
    "message": "Los campos 'Name' y 'Email' no pueden ser 'Empty'.",
    "data": null
}
 ```
### Codigos de Estado HTTP:
#### Códigos de Estado:
- `200 OK`: Solicitud Exitosa.
- `400 Bad Request`: Solicitud inválida.
- `500 Internal Server Error`: Error interno del servidor.
### Errores Comunes y Manejo de Excepciones:
#### Errores Comunes:
- `400 Bad Request`: Parámetros de entrada inválidos.

#### Manejo de Excepciones:
- Validar todos los parámetros de entrada antes de procesar la solicitud.
- Utilizar try-catch para capturar y manejar excepciones internas del servidor.
- Retornar mensajes de error claros y descriptivos.

## Uso del API NumbericReader
Ahora seguiremos con la guia de como utilizar la API de **NumericReader**.
 - **URL:** `/api/NumericReader`.
 - **Método HTTP:** `POST`

### Headers Requeridos
- `Content-Type`: `application/json`
- `Authorization`: `Bearer Token` (obligatorio)

### Parámetros de Entrada:
 - `number` (obligatorio): Número que se desea obtener su respectivor lector (Debe ser un número entero de 0 a 999.999.999.999). Tipo: `long`.
### Parámetros en el Cuerpo de la Solicitud (Request Body):
 ```json
{
    // Número entero entre 0 y 999.999.999.999
    "number": 12332450
}
 ```
### Ejemplo de Solicitud:
```bash
curl --location 'http://www.inalambriatest.somee.com/api/NumericReader' \
--header 'Content-Type: application/json' \
--header 'Authorization: <Bearer Token> \
--data '{
    "number": 12332450 
}'
```
### Respuesta del Endpoint (Response):
**Formato de la respuesta:** `application/json`.
#### Ejemplo de Respuesta Exitosa:
 ```json
{
    "statusCode": 200,
    "isSuccess": true,
    "message": "Conversión exitosa",
    "data": "doce millones trescientos treinta y dos mil cuatrocientos cincuenta"
}
 ```
### Ejemplo de Solicitud con Error:
```bash
curl --location 'http://www.inalambriatest.somee.com/api/NumericReader' \
--header 'Content-Type: application/json' \
--header 'Authorization: <Bearer Token> \
--data '{
    "number": null
}'
```
#### Ejemplo de Respuesta de Error:
 ```json
{
    "statusCode": 400,
    "isSuccess": false,
    "message": "El campo 'Number' no puede ser 'Null'",
    "data": null
}
 ```
### Codigos de Estado HTTP:
#### Códigos de Estado:
- `200 OK`: Solicitud Exitosa.
- `400 Bad Request`: Solicitud inválida.
- `500 Internal Server Error`: Error interno del servidor.
### Errores Comunes y Manejo de Excepciones:
#### Errores Comunes:
- `400 Bad Request`: Parámetros de entrada inválidos.

#### Manejo de Excepciones:
- Validar todos los parámetros de entrada antes de procesar la solicitud.
- Utilizar try-catch para capturar y manejar excepciones internas del servidor.
- Retornar mensajes de error claros y descriptivos.

