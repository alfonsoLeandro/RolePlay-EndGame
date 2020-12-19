# Universidad Católica del Uruguay
<img src="https://ucu.edu.uy/sites/all/themes/univer/logo.png" alt="Logo UCU"> 

# Programación II - Leandro Alfonso
# RolePlay - End game

Resumen del proyecto:

## Tabla de contenidos:
1. [Introducción](#intro)
    1. [Personajes](#chars)
        1. [Héroes](#heroes)
        2. [Villanos](#villains)
    2. [Items](#items)
        1. [Items mágicos](#magic)
        2. [Items NO mágicos](#nonmagic)
        3. [Items excepcionales](#exceptional)
        4. [Items compuestos](#compound)
    3. [Encuentros](#encounters)
        1. [Encuentros de intercambio](#exchange)
        2. [Encuentros de batalla](#battle)
    4. [Campo de los caídos](#honor&glory)
2. [Diseño e implementación](#diseño)
    1. [Patrones utilizados](#patrones)
        1. [Singleton](#singleton)
        2. [Expert](#expert)
        3. [Creator](#creator)
        4. [SRP](#srp)
        5. [Adapter](#adapter)
        6. [OCP](#ocp)
        7. [COR](#cor)
3. [Descripción de algunas clases](#clases)
    1. [Juego](#juego)
6. [Consideraciones](#consideraciones)

<a name ="intro"></a>
## 1. Introducción

A lo largo de todo el semestre hemos acompañado a nuestros héroes en sus aventuras y batallas por la tierra media, ya es momento de darle fin a las pequeñas batallas y ganar la guerra por el control de la tierra media.

Para ello nuestros héroes se enfrentaran a sus enemigos en encuentros a sangre fría, donde el último en pie se proclamara como amo y señor de toda Tierra Media. Para Estos encuentros vamos a contar con algunos de los siguientes personajes.



<a name="chars"></a>
## 1.i Personajes
Existen dos bandos: los héroes y los villanos. Estos bandos son enemigos.
Cada personaje cuenta con 3 estadísticas. Éstas son: puntos de vida o salud (se ve directamente afectada cuando un personaje es atacado),
defensa (al ser atacado, la defensa puede tener un papel importante en prevenir que el personaje sea afectado por el golpe (Se elige un numero random entre
 0 y los puntos de defensa del personaje)) y finalmente el ataque, es este valor el que se usa durante los ataques. Cada personaje tiene un valor por defecto para
 cada estadística y son los [items](#items) los que se encargan de "boostear" (incrementar) cada una de ellas dependiendo del item.

<a name="heroes"></a>
### 1.i.a Héroes
El bando de los héroes está conformado por:
- Angel: Bajó del cielo para proteger a los heroes y pelear a su lado.
- Archer: Ni el mismísimo legolas pudo abstenerse de participar en la batalla.
- Dwarf: Su baja estatura lo ayuda a infilitrarse entre las piernas de sus enemigos, su principal objetivo.
- Elf: Puede parecer simple, pero hay pocas criaturas más confiables que este elfo.
- Fairy: Aunque su especialidad no es el ataque, sirve para distraer a los enemigos de otros heroes.
- Knight: El mismisimo todo-poderoso Sir Lancelot. No necesita introducción.
- OverLord: Una bestia todo-poderosa capaz de abatir cualquier orco.
- ShadowHunter: Un shadow hunter es el encargado de luchar contra los demonios y el mismisimo satan. Ya que es el único con los conocimientos necesarios y tienen sangre angelical.
- Wizard: El único heroe que puede portar items mágicos, tales como pociones, entre otros.


<a name="villains"></a>
### 1.i.b Villanos
El bando de los villanos está conformado por:
- Caronte: El encargado de guiar a las sombras errantes de los reciente difuntos de un lado al otro del río aqueronte.
- Cerberus: La enorme bestia de 3 cabeza encargada de proteger la puerta del reino de hades.
- Demon: Sirviente leal del mismísimo satán
- Dragon: Una bestia con alas que escupe fuego por su boca con afilados dientes.
- Orc: Una bestia muy bruta y sin temor a nada. El principal enemigo de los caballeros.
- Satan: El mismísimo señor del infierno. La peor pesadilla de cualquier héroe. Sus estadísticas finales son el doble del total de sus estadisticas atribuidas.
- Vampire: Una bestia chupa-sangre encargada de succionar el alma de cada héroe.
- Werewolf: Una mezcla entre hombre y lobo que resulta muy peligroso para cualquier héroe de carne y hueso.
- Witch: Es la contra de los hechiceros por parte de los villanos ya que también puede portar items mágicos.

<a name="items"></a>
## 1.ii Items
Existen tres grandes tipos de items: Los items mágicos, los no mágicos y los excepcionales. Estos últimos son un 
caso especial de items no mágicos, ya que son considerados por naturaleza no mágicos pero aún así tienen habilidades especiales.
Además de estos 3 tipos de items se podría considerar otro pequeño tipo de item
Cualquier clase de item puede ser portado tanto por heroes como villanos, la única diferencia entre los items mágicos y
los no mágicos siendo que solamente los personajes de tipo "Wizard" y "Witch" pueden portar items de tipo mágico.
Además de estos 3 tipos de items, existe una clase especial de items, se trata de los items compuestos, estos surgen de combinar un item con otro
existen items compuestos mágicos e items compuestos no mágicos.

<a name="magic"></a>
### 1.ii.a Items mágicos
Los items mágicos pueden ser portados tanto por un Wizard como por un Witch únicamente. Estos son:
- FireBall: Una bola de fuego valyrio, un tipo de fuego especial que solamente puede ser manipulado por alguien con los conocimientos necesarios.
- ForbiddenStaff: Una vara demasiado poderosa como para que un simple mortal la tenga en su posesión.
- ForceField: Un campo de fuerza alrrededor del personaje que aumenta sus estadísticas de defensa y HP.
- ProtectingBelt: Un cinto de tecnología avanzada que permite defender al portador de ataques varios.


<a name="nonmagic"></a>
### 1.ii.b Items NO mágicos
Estos son los items que llamaríamos "comunes", items que puede portar cualquier personaje. Son los siguientes:
- Shield: Un escudo de madera con bordes del mejor acero.
- SharpShield: Un escudo de madera con borde del mejor acero, forjado y afilado por el mejor herrero del condado.
- Sword: Puede parecer una simple espada pero es más que eso, es una espada de acero valyrio, el metal más fuerte jamás conocido por el hombre.
- Trident: El mismísimo tridente de poseidón.
- Pociones: Dentro de estos items existen pociones, dentro de ellas las siguientes:
    - CuringPotion: Una poción curativa, agrega HP a cualquiera que la tenga en su posesión.
    - OPPotion: Una poción demasiado poderosa para cualquiera (OverPowered), puede mejorar hasta las 3 estadísticas de un personaje y sus efectos finales se ven multiplicados 3 veces a los ingresados.
    - RecoveryPotion: Ayuda a un personaje a salir de un momento difícil con un boost de HP y defensa.
    - ResistancePotion: Ayuda a la defensa de un personaje.
    - StrengthPotion: Incrementa la fuerza total de un personaje, por ende afectando directamente su capacidad de ataque.


<a name="exceptional"></a>
### 1.ii.c Items excepcionales
Estos items pueden ser mágicos o no, pero todos tienen una habilidad especial, estas se dan por lo general al combinar
uno de estos items con otro, excepcional o no, dependiendo del item. Estos son los siguientes:
- AscleipoStaff: Esta vara, por si sola es un item no mágico y tiene estadísticas de los 3 tipos, pero al combinarse (con un item mágico no compuesto)permite que cualquier personaje posea el item resultante ya que se trata de un item compuesto no mágico.
- DarkSword: Se trata de una espada, que por defecto no trae ninguna estadística especial, pero al agregar gemas elementales (más sobre estas en el siguiente item) estos se combinan automática o manualmente formando una nueva DarkSword con las estadísticas de esta gema. Las gemas para cada espada son stackeables, es decir que una DarkSword puede tener infinitas gemas elementales.
- ElementalGem: Son items que por si solos no agregan estadísticas pero suman estadísticas a una DarkSword si el personaje posee ambos items y finalmente es la DarkSword la que añade las estadísticas al personaje.
- SpellBook: Se trata de un item similar a la DarkSword pero con las siguientes diferencias: se trata de un item mágico y en vez de utilizar gemas elementales utiliza "Spells".
- Spell: Son las gemas elementales de los Spells book, simbolizan un hechizo que un Wizard puede agregar a su libro de hechizos.


<a name="compound"></a>
### 1.ii.d Items compuestos
Existen los items compuestos mágicos y los items compuestos no mágicos, dependiendo de como fue la formación del mismo.
Estos son limitados y surgen de la combinación de dos items no compuestos, mágicos o no. Como con todos los items anteriores,
hay mucho espacio para expansión, es decir se pueden agregar más items compuestos muy fácilmente si así se desea, ya que existen las
abstracciones necesarias para lograr esto; dicho esto vale la pena aclarar que por lo general los items compuestos se pueden
generar por ambos "ingredientes", es decir, puedo generar un "Shield and sword" tanto desde la clase Shield (usando Shield#Combine(Sword sword))
como desde la clase Sword (utilizando Sword#Combine(Shield shield)).

### Items compuestos mágicos
- Fireball + ForbiddenStaff: Genera una vara prohibida que tira bolas de fuego.

### Items compuestos no mágicos
- Shield/SharpShield + Sword: Genera la clásica combinación de espada y escudo. Si se trata de un escudo, el mismo añadirá defensa, pero si se trata de un escudo filoso éste añadirá defensa y daño al personaje.
- Shield/SharpShield + Trident: Genera una combinación de tridente y escudo. Si se trata de un escudo, el mismo añadirá defensa, pero si se trata de un escudo filoso éste añadirá defensa y daño al personaje.
- Sword + Sword: Genera unas espadas cruzadas, pensadas para ser utilizadas una en cada mano por el personaje portador del item.

<a name="encounters"></a>
## 1.iii Encuentros
Estos son cada uno de los encuentros entre 1 o más heroes con uno o más villanos, dependiendo del tipo de encuentro.

<a name="exchange"></a>
### 1.iii.a Encuentros de intercambio
En estos encuentros solamente participan 2 personajes por encuentro, estos pueden ser dos heroes, dos villanos o un héroe y un villano.
En este tipo de encuentro el objetivo final no es la batalla si no intercambiar un item. Uno de los dos personajes será el encargado de ceder un item
mientras que el otro personaje se encargará solamente de recibir este item. Puede suceder que se intente ceder un item mágico
a un personaje que no sea un Wizard o un Witch, en este caso el intercambió fallará y el encuentro no tendrá éxito.


<a name="battle"></a>
### 1.iii.b Encuentros de batalla
En estos encuentros nos dejamos de dar vueltas y vamos derecho a lo que importa. Existe una lista de héroes con al menos un héroe y otra lista de villanos
con al menos un villano.
Cuando el encuentro toma lugar, los héroes batallarán contra los enemigos, de la siguiente forma:
- Los enemigos atacan primero. Cada enemigo ataca únicamente a un héroe. Si hay un sólo héroe, todos los enemigos atacan al mismo. Si hay más de un enemigo y más de un héroe, el primer enemigo ataca al primer héroe, el segundo enemigo ataca al segundo héroe, y así sucesivamente. Si hay menos héroes (N) que enemigos (M), el siguiente enemigo (N+1) ataca al primero héroe, el siguiente enemigo (N+2) ataca al segundo héroe, y así sucesivamente.
- Luego, los héroes sobrevivientes atacan a los enemigos. Todos los héroes atacan a cada uno de los enemigos 1 vez.
- Cada vez que un héroe mata a un enemigo, ese héroe se lleva los VP del enemigo que ha vencido.
- Se repite el primer punto.
- El encuentro termina cuando todos los héroes o todos los enemigos han muerto.
- Si un héroe ha conseguido 5+ (5 o más) VP, se cura, volviendo a tener el total de su vida.


<a name="honor&glory"></a>
## 1.iv Campo de los caídos
TODO


<a name="diseño"></a>
## 2. Diseño e implementación
En este capítulo escribiré los detalles del diseño y la implementación por mi parte en este proyecto,

<a name="patrones"></a>
### 2.1. Patrones utilizados
