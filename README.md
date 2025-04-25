Esta API fue creada en Net 8  con un enfoque monolitico de N capas; se utiliza Entity Framework como ORM lo que permite un control mas preciso y general de las entidades y su manipulacion final a la base de datos.
Se crearon tres capas principales: la de presentación para su consumo del API, la de negocio para las reglas propias del cliente y la de dominio o acceso a data donde se diseñó un repositorio generico para estandarizar los procesos de consulta, creacion y eliminacion de información.
Existen otros tres encarpetados que son abstracciones de un "capa transversal" donde se almacena las entidades y los DTO necesarios porque se usa el AutoMapper para la recepcion de datos al consumir el API y su respuesta, ademas una capa de "dependencias" donde mediante servicios AddScoped, AddTransient, AddDbContext y AddAutoMapper se registran todas las interfaces y clases que las implementan para su posterior inyeccion donde sea requerido, por ultimo esta la capa encargada de mapear las entidades y los DTO.
![image](https://github.com/user-attachments/assets/76f951b4-5550-4056-97b0-de216865bfe1)

El API cuanta con swagger para su documentacion
![image](https://github.com/user-attachments/assets/ab38919f-bf19-40da-ab85-6e336b9caf4b).
Al momento de clonar el repositorio hacer click derecho sobre la solucion y la opción "Restaurar paquetes de Nuget". 

En caso de que deba ser a mano estos son los paquetes necesarios :
capa presentación : ![image](https://github.com/user-attachments/assets/151dcdc0-6a59-4b34-a265-54377efe511f)
capa acceso a data : ![image](https://github.com/user-attachments/assets/1d0b8892-6df2-411e-bd9b-aa57e0eaebdd)
dependencias : ![image](https://github.com/user-attachments/assets/c842213c-d635-47b5-b4df-0813670011fd)
utilidades: ![image](https://github.com/user-attachments/assets/8cc52482-2669-4adc-b065-1a09de76f91e)

nota importante!!: en este repositorio se encuenta el query sql server para crear la base de datos y alguna informacion ya preestablecida. Es importante cambiar en el app settings 
![image](https://github.com/user-attachments/assets/cbd055a7-2af7-45b5-9192-538719579bff)
el Source ques el nombre del server local donde se ejecute el query y el Catalog que es el nombre de la base de datos, por defecto se creará con el nombre "ELCLIENTE"
















