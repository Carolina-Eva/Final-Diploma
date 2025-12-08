# 📄 PATRÓN STATE (Mini Juego de Granja)

Enunciado:

Se desea simular un mini-juego de gestión de una granja, en el cual el jugador interactúa con distintas parcelas de tierra. Cada parcela puede encontrarse en varios estados, y dependiendo del estado actual, las acciones disponibles y los resultados posibles son diferentes.
El propietario de la granja puede realizar tres acciones principales sobre una parcela:

- Plantar una semilla
- Regar la tierra/semilla
- Cosechar el cultivo

La parcela debe cambiar de estado en función de las acciones realizadas por el jugador, cumpliendo el siguiente ciclo de crecimiento:

* TierraLibre: no hay cultivo; si el jugador planta, pasa al estado SemillaPlantada.
* SemillaPlantada: si se riega por primera vez, pasa al estado Creciendo.
* Creciendo: si se riega por segunda vez, pasa al estado ListaParaCosechar.
* ListaParaCosechar: si el jugador cosecha, vuelve al estado TierraLibre.

Cada estado debe definir su propio comportamiento ante las acciones Plantar, Regar y Cosechar, pudiendo permitirlas o ignorarlas según corresponda. No deben utilizarse estructuras condicionales extensas; la lógica debe organizarse utilizando el patrón de diseño State, delegando el comportamiento en clases concretas que representen cada estado.
