# ProyectoWeddingP

Se trata de una aplicación de escritorio en C# utilizando consta de varias ventanas y tecnmologias como sqlite, XAML y C#
-Una ventana inicial de bienvenida con un boton de inicio
el cual activa la ddbb en sqlite
-La aplicación cuenta con una ventana de login, donde los usuarios deben ingresar su nombre de usuario y contraseña para acceder a la aplicación o la opcion de registrarse que llama a otra ventana.
-ventana Registrarse:
-Una vez dentro, se les presenta una pantalla principal que muestra la cuenta regresiva para su boda, junto con información personal como el nombre del usuario y la fecha de su boda.
-La información de los usuarios se almacena en una base de datos SQLite, donde se guardan el nombre de usuario, la contraseña, la fecha de la boda y otros detalles.
Además de la cuenta regresiva principal en la pagina de inicio, la aplicación cuenta con otras funciones, como la capacidad de editar la información personal del usuario, cambiar la fecha de la boda y actualizar la cuenta regresiva en tiempo real. La aplicación también permite a los usuarios cancelar su cuenta y eliminar su información de la base de datos.
la Pagina de inicio cuenta con botones que controlan las pestañas, las cuales tienen diferentes tareas.
Invitados: en esta pestaña, es posible que los usuarios puedan agregar o eliminar invitados de la lista. También podrían confirmar si un invitado ha respondido y si asistirán a la boda.
esta información la manejo con una tabla de invitados que esta asociada a la cuenta principal
Para la pestaña Tareas, puedes crear un formulario que tenga una lista de tareas pendientes y un formulario para agregar nuevas tareas, así como eliminarlas.

Aún me queda la parte de proveedores y presupuesto, las cuales tendran relación.

La bbd de sqlite crea el archivo cada vez que este se incia.
consta de momento de tres tabalas usuarios, tareas e invitados.
He puesto los metodos en esta misma pestaña.
