# Manual Técnico

## Objetivo General
La finalidad de la aplicación es poder llevar un control de las entradas y salidas de los empleados de una empresa. Para ello se crearon los distintos servicios web que puedan ser consumidos desde una aplicación Laravel.

## Herramientas de desarrollo

### .NET CORE
.Net Core es un framework desarrollador por Microsoft. Este se utilizó en el backend para poder desarrollar la aplicación. La versión que fue utiliza es la .NET 5.

### SQL SERVER
SQL Server es un sistema de manejo de base de datos relacionales, el cual se utilizó para almacenar todos los datos generados desde la aplicación.

### Entity framework
Entity framework es un ORM que nos facilita las consultas con la base de datos. Este framework nos permite trabar toda la información a tráves de objetos y se encarga de insertarlos a la base de datos correspondiento sin que nosotros tengamos que escribir codigo SQL.

# Rider
Rider es un entorno de desarrollo que facilita el desarrollo de aplicaciones .NET Core.

## Estructura del proyecto
La aplicación es un proyecto de web services que brinda una API para poder realizar todas las operaciones necesarias. El proyecto se desarrollo por medio de la arquitectura MVC que nos permite dividir el proyecto dependiendo de la funcionalidad, pero además se utilizo la arquitectura de capas, ya que se crearon repositorios para poder facilitar el acceso a la base de datos.

### Models
La carpeta models contiene todos los modelos de la aplicación. Esta es la encargada de almacenar todas aquellas clases que van a hacer mapeadas a tablas en la base de datos.

### Repositories
El directorio repositories almacena todas las clases e interfaces necesarias para la manipulación de la información.

El objetivo de las interfaces es definir un contrato que debe ser cumplido en la clase que implemente dicha interfaz. Las intefaces definen los métodos necesarios para la manipulación de la información.

Las clases se encargan de la implementación de las intefaz, en estas se define toda la lógica necesaria para la manipulación de información.

El objetivo de las interfaces y las clases es poder implementar Dependency Injection.

### Services
El directorio service se encarga de la implementación de servicios que brindan una funcionalidad en la aplicación. Para la actual aplicación se crea el servicio de **UserService** el cual nos permite la funcionalidad de autenticar a un usuario por utilizando el repositorio para validar su existencia.

### Helpers
El directorio helpers cuenta con clases que sirven de ayuda para la aplicación. En nuestra aplicación solamente existe un helper el cual es un manejador que nos permite la implementación de la autenticación básica.

### Configuration
El directorio configuration tiene las clases que se utilizan para la inserción de datos que son necesario para el correcto funcionamiento de la aplicación. En general son seeders que nos permiten contar con la información que la aplicación necesita para su funcionamiento.

### Controllers
Los controladores son los encargados de recibir las peticiones por parte de los usuarios y responder utilizando los distintos servicios y repositorios.
