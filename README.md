# Coding Challenge

## Descripción

La aplicación de este código se encarga de realizar el análisis de perfiles de la aplicación LinkedIn y determinar los 100 mejores perfiles para considerarse clientes potenciales de la compañía.

La información de los perfiles se obtiene mediante el archivo people.in el cual contiene información de nombres, role, ubicación, contactos, recomendaciones a partir de las cuales se realiza este análisis.

## Reglas de Negocio

* Se analiza el rol de las personas de acuerdo a una lista de roles definidos que son de interés para la compañía, en específico puestos directivos como CEO, CTO, Director, VP, y similares.

* Se da mayor puntaje a los individuos que pertenezcan a industrias relacionadas con los clientes de la compañía tal como lo indica el sitio web de la misma: https://www.bairesdev.com/clients/

* Se tienen en cuenta las recomendaciones y conexiones de los perfiles. Siendo de más importancia las conexiones ya que en caso de éxito esto puede abrir opciones de nuevos negocios.

## Ejecución

Se incluye una carpeta ejecución la cual se recomienda descargar para realizar la prueba (debe descargar la carpeta completa) en la cual está el archivo ejecutable CodeChallenge.exe. Dentro de la misma carpeta se debe colocar el archivo people.in el cual se quiere analizar y el programa generara un archivo people.out.


## Plan de Mejoras

* Tener una fuente de verdad sobre los criterios que serían importantes y que pueda ser actualizable por algún usuario de tal manera que tanto los roles como las industrias de interés puedan definirse de acuerdo a cada necesidad.

* Determinar si la ubicación geográfica del cliente es importante para la selección y aplicar un sistema de peso similar.
