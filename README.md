# Universidad Católica del Uruguay
<img src="https://ucu.edu.uy/sites/all/themes/univer/logo.png"> 

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
- Satan: El mismísimo señor del infierno. La peor pesadilla de cualquier heroe. Sus estadpisticas finales son el doble del total de sus estadisticas atribuidas.
- Vampire: Una bestia chupa-sangre encargada de succionar el alma de cada heroe.
- Werewolf: Una mezcla entre hombre y lobo que resulta muy peligroso para cualquier heroe de carne y hueso.
- Witch: Es la contra de los hechiceros por parte de los villanos ya que también puede portar items mágicos.

<a name="items"></a>
## 1.ii Items
Existen tres grandes tipos de items: Los items mágicos, los no mágicos y los excepcionales. Estos últimos son un 
caso especial de items no mágicos, ya que son considerados por naturaleza no mágicos pero aún así tienen habilidades especiales.
Además de estos 3 tipos de items se podría considerar otro pequeño tipo de item
Cualquier clase de item puede ser portado tanto por heroes como villanos, la única diferencia entre los items mágicos y
los no mágicos siendo que solamente los personajes de tipo "Wizard" y "Witch" pueden portar items de tipo mágico.

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
    - OPPotion: Una poción demasiado poderosa para cualquiera (OverPowered), puede mejorar hasta las 3 estadisticas de un personaje y sus efectos finales se ven multiplicados 3 veces a los ingresados.
    - RecoveryPotion: Ayuda a un personaje a salir de un momento dificil con un boost de HP y defensa.
    - ResistancePotion: Ayuda a la defensa de un personaje.
    - StrengthPotion: Incrementa la fuerza total de un personaje, por ende afectando directamente su capacidad de ataque.


<a name="exceptional"></a>
### 1.ii.c Items excepcionales