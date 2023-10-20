# VeterinariaCampus 🐶🐱⚕️
## Introduccion
La VeterinariaCampus es un proyecto desarrollado en NetCore con el proposito de elaborar una api funcional que permita gestionar una veterinaria, implementando funcionalidades con las cuales se pueda manipular informacion relacionada con el agendamiento de citas, medicamentos, proveedores, compras, etc.

## Caracteristicas
- Gestion de Veterinarios
- Gestion de Mascotas
- Movimiento de Medicamentos
- Registro de Usuario
- Asignacion de Roles
- Inicio de Sesion

## Consultas

### Basicas
- Crear
```
[POST]localhost:5048/api/[Nombre de la entidad]
```
- Editar
```
[PUT]localhost:5048/api/[Nombre de la entidad]/{id}
```
- Eliminar
```
[DELETE]localhost:5048/api/[Nombre de la entidad]/[id]
```
- Listar v1.0
```
[GET]localhost:5048/api/[Nombre de la entidad]
```
- Listar v1.1
```
[GET]localhost:5048/api/[Nombre de la entidad]
```
```
X-Version : 1.1
```
### JWT
#### Registrar
- Endpoint
```
http://localhost:5048/api/User/Register/
```
#### Token
- Endpoint
```
http://localhost:5048/api/User/Token/
```
#### Añadri rol
- Endpoint
```
http://localhost:5048/api/User/addrole/
```
####  Refresh Token
```
http://localhost:5048/api/User/refresh-token/
```

### Visualizar los Veterinarios Cuya Especialidad Sea [Nombre de la especialidad]
#### Endpoint
```
http://localhost:5048/api/Veterinarian/Specialty?Specialty=[Nombre de la especialidad]
```
#### Respuesta
```
[
  {
    "name": "Catty",
    "birthDate": "2020-12-12T00:00:00",
    "ownerId": 1,
    "breedId": 1,
    "specieId": 1
  },
  {
    "name": "Catty",
    "birthDate": "2020-12-12T00:00:00",
    "ownerId": 1,
    "breedId": 1,
    "specieId": 1
  }
]
```
### Listar los Medicamentos Que Pertenezcan a el Laboratorio [Nombre del laboratio]
#### Endpoint
```
http://localhost:5048/api/Medicine/Laboratories?Laboratory=[Nombre del laboratorio]
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "name": "Penicilina",
    "quantityAvailable": 10,
    "price": 10.000000000000000000000000000,
    "laboratoryId": 1,
    "laboratory": "Genfar"
  }
]
```
### Mostrar las mascotas que se encuentren registradas cuya especie sea [Nombre de la especie]
#### Endpoint
```
http://localhost:5048/api/Pet/Species?Specie=[Nombre de la especie]
```
#### Respuesta
```
[
  {
    "name": "Catty",
    "birthDate": "2020-12-12T00:00:00",
    "ownerId": 1,
    "breedId": 1,
    "specieId": 1
  }
]
```
### Listar las Mascotas y sus Propietarios Cuya Raza sea [Nombre de la raza]
#### Endpoint
```
http://localhost:5048/api/Pet/Breed?Search=[Nombre de la raza]
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "name": "Doggy",
    "owner": {
      "name": "Pepe",
      "phone": "123"
    }
  }
]
```
### Listar los Propietarios y sus Mascotas
#### Endpoint
```
http://localhost:5048/api/Owner/Pets
```
#### Respuesta
```
[
  {
    "name": "Pepe",
    "pets": [
      {
        "name": "Doggy"
      },
      {
        "name": "Catty"
      }
    ]
  }
]
```
### Listar los Medicamentos Que Tenga un Precio de Venta Mayor a [Precio de venta]
#### Endpoint
```
http://localhost:5048/api/Medicine/Price?Price=[Precio de venta]
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "name": "Penicilina",
    "quantityAvailable": 10,
    "price": 10.000000000000000000000000000,
    "laboratoryId": 1,
    "laboratory": "Genfar"
  }
]
```
### Listar las Mascotas Que Fueron Atendidas Por Motivo de [Motivo de cita] en el [Mes inicial y final] del 2023
#### Endpoint
```
http://localhost:5048/api/Appointment/MonthsAndMotive?MonthInit=[Mes inicial]&MonthFinish=[Mes final]&Reason=[Razon de cita]
```
#### Respuesta
```
[
  {
    "name": "Catty"
  }
]
```
### Listar Todas Las Mascotas Agrupadas Por Especie
#### Endpoint
```
http://localhost:5048/api/Specie/Pets?Specie=[Nombre de la especie]
```
#### Respuesta
```
[
  {
    "name": "Cat",
    "pets": [
      {
        "name": "Catty"
      }
    ]
  },
  {
    "name": "Dog",
    "pets": [
      {
        "name": "Doggy"
      }
    ]
  }
]
```
### Listar las mascotas que fueron atendidas por un determinado veterinario
#### Endpoint
```
http://localhost:5048/api/Appointment/Veterinarian?Search=[Nombre veterinario]
```
#### Respuesta
```
[
  {
    "name": "Catty",
    "birthDate": "2020-12-12T00:00:00",
    "ownerId": 1,
    "breedId": 1,
    "specieId": 1
  },
  {
    "name": "Catty",
    "birthDate": "2020-12-12T00:00:00",
    "ownerId": 1,
    "breedId": 1,
    "specieId": 1
  }
]
```
### Listar los proveedores que me venden un determinado medicamento
#### Endpoint
```
http://localhost:5048/api/Supplier/GetForMedicine?Search=[Nombre medicamento]
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "name": "Pepito",
    "direction": "123",
    "phone": "123"
  }
]
```
### Listar la Cantidad de Mascotas Que Pertenecen a Una Raza
#### Endpoint
```
http://localhost:5048/api/Breed/GetWithCount
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "name": "Orange",
    "quantity": 1
  },
  {
    "name": "Golden",
    "quantity": 1
  }
]
```
### Listar Todos Los Movimientos de Medicamentos y El Valor Total De Cada Movimiento
#### Endpoint
```
http://localhost:5048/api/MedicineMovement/Total
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "id": 1,
    "date": "2023-12-12T00:00:00",
    "movementType": "Sale",
    "total": 10
  }
]
```
## Autor
- Juan Pablo Lozada