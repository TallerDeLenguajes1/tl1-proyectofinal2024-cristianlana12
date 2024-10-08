*PROYECTO FINAL*
*Alumno: Cordoba, Cristian Federico*
*DNI: 44.408.642*
*Carrera: Ingenieria en Informatica*

# DRAGON BALL Z - TORNEO DE ARTES PARCIALES
*DRAGON BALL Z - TORNEO DE ARTES MARCIALES es un juego basado en batallas, inspirado en la mítica serie Dragon Ball creada por el maestro Akira Toriyama (1982-2024). El juego permite realizar combates aleatorios con personajes de la saga.*

# Jugabilidad 
*El juego solo tiene un solo estilo de torneo*
*4 peleadores aleatorios donde uno de estos 4 sera el que el usuario elija*
*El usuario tiene la posibilidad de elegir solo 3 personajes*
    *1_ Goku*
    *2_ Vegueta*
    *3_ piccolo*

*Durante el combate:*
*A_ Si es el turno de pelear del personaje que seleccionaste, podras interactuar con el menu de combate donde tiene las opciones de ataque base, ataque especial(Si es que posee),  pasar de ronda*
*B_ Si no es el turno de pelear del personaje seleccionado, el personaje de turno lo que hara sera elegir alguna de estas opciones de forma aleatoria en el caso de que no tenga alguna de las opciones solo elije opciones aleatorias entre sus posibilidades*

# Recursos utlizados
*El juego utiliza la api de Dragon ball Api (url: https://web.dragonball-api.com/)*
## Metodo asincronico
*El método Get(int id) es asíncrono y retorna un objeto de tipo Task<CharactersPersonaje?>. Esto significa que el método puede ejecutarse en segundo plano sin bloquear el flujo principal de la aplicación.*
## Construcción de la URL:
*La URL de la API se construye dinámicamente utilizando el ID del personaje. Se define en la variable url mediante interpolación de cadenas: var url = $"https://dragonball-api.com/api/characters/{id}". Aquí, {id} es reemplazado por el valor del ID pasado al método, lo que permite acceder a un recurso específico en la API.*
## Manejo de Errores:
*Si ocurre alguna excepción durante la solicitud (por ejemplo, si la API no está disponible), el código captura la excepción y muestra un mensaje de error en la consola.*
*Luego, en caso de error, se utiliza un método de respaldo ConsumoBackup.ObtenerPersonaje(id) para obtener el personaje, asegurando que el programa pueda continuar funcionando.*

# Requisitos 
*1_Sistema operativo windows*
*2_.Net 8.0*
*3_Clonar el repositorio con: git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-cristianlana12.git* 
*Se le descargara la carpeta tl1-proyectofinal2024-cristianlana22*
*Abrir esta carpeta desde Visual Studio Code y ejecutar desde la terminal "dotnet run"*

# "Eres un ser increíble, diste lo mejor de ti y por eso te admiro. Pasaste por varias transformaciones, fuiste tan poderoso que todos nosotros te odiamos." - Akira Toriyama - En nuestros corazones por siempre. #
