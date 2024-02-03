En este proyecto vemos ejemplos de
* Variables de entorno mapaeadas al Iconfiguration
* Mapear subsecciones de appsettings.json a una clase por DI

# Variables de entorno mapaeadas al Iconfiguration. 

.Net core mapea las variables de entorno y se recuperan como si fueran variables en el archivo de configuracion appsettings.json. Para ello usa la notacion especial de dos guiones bajos para separar clave valor. Si tenemos 
```
"ApiAmazon":{
    "user": "juan"
  },
  ```
Podemos meter una variable de entorno llamada ApiAmazon__password. Para pasar variables de entorno en dev, podemos hacerlo 
* por el pc
* por el archivo launchSettings.json
* por el dockerfile

En este caso lo hemos hecho por los últimos Variables de entorno pasadas desde el dockerfile lo que simula un entorno productivo y el caso de launchsettings.json que simula el entorno de desarrollos

# Mapeamos un objeto configuración desde appsettings.json a una clase

Finalmente Mapeamos un objeto desde json a una clase. Esto es muy util para coger subsecciones del archivo de configuración y mapearlas a un objeto que inyectas como dependencia
```
 "Position": {
    "Title": "Editor",
    "Name": "Joe Smith"
  }
 ```

# Por qué todo este lio de las variables de entorno?

El caso era usar un vaul para evitar almacencar las contraseñas en los repositorios de código
