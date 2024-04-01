::: info 🎵 [Carl Sagan](https://en.wikipedia.org/wiki/Carl_Sagan) ([probably](https://www.youtube.com/watch?v=zSgiXGELjbc))
*"If you wish to make a coffee cup from scratch,  
you must first invent the universe."*
:::

::: info Abstract
![](from-scratch.png){style=float:right;margin-top:-50px;margin-right:-10px}

We build a simple world model that considers natural astronomical bodies in the celestial neighbourhood of planet Arrakis.
We then extend the model to simulate cyclic changes to planet's environment with passing of time.
We equip the model with set of parameters and validation logic based on established methods from [celestial mechanics](https://en.wikipedia.org/wiki/Celestial_mechanics), [energy engineering](https://en.wikipedia.org/wiki/Energy_engineering) and other fields
to allow simulation of different worlds bounded by the same predictable set of basic rules.

[Read the background story](../the-story/index.md)
:::

## Celestial Neighbourhood

::: tip 🔰 Lore
Delving into the model right away is tempting, but getting high on code is not the way of [Atreides](https://en.wikipedia.org/wiki/Dune_(franchise)#The_rise_of_the_Atreides).
We resist the temptation, take a step back and review what we do and do not know.
:::

Arrakis is a **third planet** of a **single star system** with day and year length similar to that on Earth. It has **two moons** that contribute to its arid climate and harsh weather patterns.  
The larger moon is said to interfere with planet's magnetic field and communication satellites in planet's orbit.

![](celestial-neighbourhood.png)

::: tip Assumptions
###### :a:ASS-01: Negligible influence of other planets.{#ASS-01}  
Other planets are out of scope of the model.

###### :a: ASS-02: Circular orbits.{#ASS-02}  
Orbits of all celestial bodies are circular.  
The [mean orbital velocity](https://en.wikipedia.org/wiki/Orbital_speed) of each celestial body is constant.
:::

## Theory

::: tip 🔰 Lore
In the week before departure to Arrakis, when all the final scurrying about had reached a nearly unbearable frenzy,
we read through textbooks to learn about orbital dynamics and celestial bodies.
One weighty tome in particular captured our attention.  

Titled ["The Lamp of Dyēus, Zeus Patēr and Jupiter"](https://en.wikipedia.org/wiki/*Dy%C4%93us),
this old text from [long gone planet](https://scifi.stackexchange.com/questions/184880/what-happened-to-old-earth-in-the-dune-saga)
described how people there harvested power of their local star, The Sun. We've learned a great deal from it, but some passages have faded and are now lost to time,
just like the men and women who meticulously tried to preserve them in ink.
:::

Following chapters explain theory behind the world model. They gradually introduce new concepts and are best reviewed in order presented below.

* [Stars](stars/index.md)  
  *Black-body, Stefan-Boltzmann Law, Solid Angle, Solar Irradiance, Radiant Energy*
* [Mechanics of Stable Orbits](stable-orbit-mechanics/index.md)  
  *Sphere of Influence, Roche Limit, Moon Stability Criterion*
* [Moons](moons/index.md)  
  *Total Eclipse, Alignment of Orbital Planes, Angular Diameter, Total Eclipse Criterion*
* [Star Selector](star-selector/index.md)  
  _Interactive star selector inspired by **Hertzsprung–Russell Diagram**_