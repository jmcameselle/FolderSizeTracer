# FolderSizeTracer
Aplicación de escritorio para localizar las carpetas con mayor ocupación de la unidad seleccionada

##Objetivo

La intención de implementar esta sencilla aplicación fue la de suplir una carencia que tiene, a mi juicio, el explorador de archivos windows.

Esta carencia es la dificultad de localizar rápidamente aquellas carpetas de una unidad que tengan una ocupación de espacio alta. Me encontré con ella en los momentos en que el sistema me alertaba de que una determinada unidad estaba al máximo de su capacidad. Me costaba mucho averiguar dónde podía eliminar archivos para liberar espacio.

El buscador integrado en el explorador permite filtrar por tamaño de archivo, con lo que, si tu unidad está saturada por archivos de gran tamaño, el explorador sí te es de gran ayuda.

Pero si el problema es que en tu unidad saturada lo que hay son carpetas que contienen muchos archivos de tamaños normales, será muy difícil localizar dónde puedes hacer limpieza. Y más si estas carpetas están muy hundidas en el árbol.

Con esta aplicación podremos listar de manera muy cómoda, de mayor a menor ocupación, las carpetas que más espacio ocupen de nuestra unidad.

Además, se incorpora la mejora de poder discriminar la búsqueda por carpetas de primer nivel, otra carencia del explorador que sólo permite la búsqueda por carpetas (y sus subcarpetas) individualmente. Con lo que, o buscas desde la raíz, o tienes que ir buscando carpeta a carpeta.

##Manejo

Al ejecutar la aplicación nos aparecerán las unidades disponibles en el equipo. Al lado aparecerán un listado de las carpetas de primer nivel y que podremos desmarcar en las que no deseemos hacer el análisis. 

Por defecto se desmarcan las de "Windows" y "Program Files" por ser muy costosas de procesar. Pero si sospechamos que es ahí donde se ubican las carpetas que podemos vaciar bastará con seleccionarlas.

Una vez terminado el proceso de análisis nos aparecerá un listado con las carpetas de mayor ubicación en primer lugar. Haciendo doble click en ellas se lanzará el explorador con esa ubicación seleccionada. Estos registros también nos informan de cuántos archivos tenemos en esa ubicación.

###Nota
Si con el usuario que estemos autenticados no disponemos permisos de lectura en una determinada carpeta simplemente se ignorará para los análisis y selección

##Información

Se trata de un proyecto de Windows Form Apliccation, escrito en C# con Microsoft Visual Studio Community 2013

Version 12.0.31101.00 Update 4
Microsoft .NET Framework
Version 4.6.00079
