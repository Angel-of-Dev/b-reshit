# Orbital Dynamics

::: info Abstract
We build a simple orbital dynamics model that considers natural astronomical bodies in the celestial neighbourhood of Arrakis. 
We equip the model with set of parameters and validation logic based on established methods from [celestial mechanics](https://en.wikipedia.org/wiki/Celestial_mechanics).
In addition, we list simplifying assumptions that can be lifted in the future to build more comprehensive models.

[Read the background story](../the-story/index.md)
:::

## Celestial Neighbourhood

Arrakis is a **third planet** of a **single star system** with day and year length similar to that on Earth. It has **two moons** that contribute to its arid climate and harsh weather patterns.  
The larger moon is said to interfere with planet's magnetic field and communication satellites in planet's orbit.

![](celestial-neighbourhood.png)

::: tip Simplifying Assumptions
**SA01: Negligible influence of other planets.**  
Other planets are out of scope of the model.

**SA02: Aligned orbital planes.**  
[Orbital inclination](https://en.wikipedia.org/wiki/Orbital_inclination) of all celestial bodies is 0°.  
The orbits of moons are aligned with planet's equator.

**SA03: Circular orbits.**  
Orbits of all celestial bodies are circular.  
The [mean orbital velocity](https://en.wikipedia.org/wiki/Orbital_speed) of each celestial body is constant.

**SA04: Length of moon's orbit is proportional to its size.**  
Smaller moon has shorter orbit, larger moon has longer orbit.  
In other words, smaller moon is closer to the planet, larger moon is further away from the planet.
:::

## Mechanics of Stable Orbits

The motion of a planet and its two moons can be thought of in terms of [Newton's laws of motion](https://en.wikipedia.org/wiki/Newton%27s_laws_of_motion) and a [three-body problem](https://en.wikipedia.org/wiki/Three-body_problem).
We are only interested in solutions that are stable over very long period of time, where orbits of moons lie within a **gravitational sphere of influence** of the planet and moons do not influence each other. 

The radius of sphere of influence is estimated in terms of distance between two objects and their mass ratio as:

::: tip [1] Radius of sphere of influence
$R \approx d \cdot \left(\dfrac {m}{M}\right)^{2/5} \approx d \cdot \left(\sqrt [5] {\dfrac {m}{M}}\right)^2$
:::

where:
* $M$, the mass of a larger object
* $m$, the mass of a smaller object
* $d$, the distance between objects

![](sphere-of-influence.png)

::: info Other Estimators
[Hill Sphere](https://en.wikipedia.org/wiki/Hill_sphere) is another popular model for estimating sphere of influence:  

$R=d \cdot \sqrt [3] {\dfrac {m}{3(M+m)}}$

Both estimators produce similar results and our choice of estimator is arbitrary.
::: 


### Arrakis Radius of Influence

Computing radius of influence of a planet provides possible locations of stable moon orbits.

We start by approximating parameters with values from our solar system:
* $m=6 \cdot 10^{24}$ kg, the approximate mass of Earth
* $M=2 \cdot 10^{30}$ kg, the approximate mass of Sun
* $d=1$ [Astronomical Unit (AU)](https://en.wikipedia.org/wiki/Astronomical_unit), the mean distance between Sun and Earth

::: tip [2] Radius of sphere of influence of Arrakis
$R_{Arrakis} \approx 1 \cdot \left(\sqrt [5] {\dfrac {6 \cdot 10^{24}}{2 \cdot 10^{30}}}\right)^2 \approx 0.006 \approx 6 \cdot 10^{-3}$ AU
::: 

The maximum distance between Arrakis and its moon is $6 \cdot 10^{-3}$ AU.

![](sphere-of-influence-distances.png)

::: info Benefits of Astronomical Unit (AU)
We could express $d$ in kilometers (~150,000,000 km), but using Astronomical Unit results in smaller numbers that are easier to work with.  

Astronomical Unit also simplifies model parametrization by requiring only a single parameter `Astronomical Unit Length` expressed in absolute terms and relating all other distances to it. 
:::

:mag_right: We know the maximum, but what about a minimum distance between a planet and its moon?

### Roche Limit

[Roche Limit](https://en.wikipedia.org/wiki/Roche_limit) is a distance from the planet within which a moon will disintegrate and form rings:

::: tip [3] Roche limit
$D=r \cdot \sqrt [3] {2 \cdot \dfrac {M}{m}}$
:::

where:
* $r$, the radius of moon
* $m$, the mass of moon
* $M$, the mass of planet

We continue by approximating parameters with values form our solar system:
* $M=6 \cdot 10^{24}$ kg, the approximate mass of Earth
* $m=7 \cdot 10^{22}$ kg, the approximate mass of Moon
* $r=1 \cdot 10^{-5}$ AU, the approximate radius of Moon (~0.00001 AU, ~1700 km)

::: tip [4] Roche limit of smaller moon
$D_{Moon} \approx 1 \cdot 10^{-5} \cdot \sqrt [3] {2 \cdot \dfrac {6 \cdot 10^{24}}{7 \cdot 10^{22}}}\approx0.00005555 \approx 5.55 \cdot 10^{-5}$ AU
:::

The minimum distance between center of Arrakis and center of its smaller moon is $5.55 \cdot 10^{-5}$ AU.

:mag_right: That's good to know, but what about a minimum distance between the moons?

### Moon Stability Criterion

Consider the following setup:
![](circular-orbit-moon-instability-regions.png)

where:
* $M$, the mass of the planet
* $m_1$, the mass of first moon
* $m_2$, the mass of second moon
* $r_1$, the radius of first moon's orbit
* $r_2$, the radius of second moon's orbit

Each moon generates a region of instability with radius $\delta_i$ represented as a gray ring along the path of its orbit. The orbits are stable when those regions do not overlap.  

We approximate $\delta_i$ as:

::: tip [5] $i$-th moon instability radius
$\delta_i \approx k \cdot R_i$
:::

where:
* $k$, the arbitrary instability constant
* $R_i$, the radius of sphere of influence of $i$-th moon

To compute $\delta_i$ of the first room we approximate parameters with values from our solar system and choose the value of $k$:
* $d_1=2.57 \cdot 10^{-3}$ AU, the average distance from Earth to Moon (~384,400 km)
* $k=5$, the arbitrarily chosen value of instability constant

::: tip [6] Radius of sphere of influence of first moon
$R_1 \approx 2.57 \cdot 10^{-3} \cdot \left(\dfrac {7 \cdot 10^{22}}{6 \cdot 10^{24}}\right)^{2/5} \approx 4 \cdot 10^{-4}$
:::

::: tip [7] Instability radius of first moon
$\delta_1 \approx 5 \cdot R_1 \approx 2 \cdot 10^{-3}$
:::

![](first-moon-sphere-of-instability.png)

Next we could calculate maximum allowed mass of the second moon and a radius of its orbit, but we stop our discovery here and write some code instead.

---

::: details References
* Seefelder, Wolfgang (2002). [Lunar Transfer Orbits Utilizing Solar Perturbations and Ballistic Capture](https://www.google.co.uk/books/edition/Lunar_Transfer_Orbits_Utilizing_Solar_Pe/NVg_vYHePt0C). Munich: Herbert Utz Verlag. p. 76. ISBN 3-8316-0155-0
* C. A. Giuppone, M. H. M. Morais, A. C. M. Correia, [A semi-empirical stability criterion for real planetary systems with eccentric orbits](https://doi.org/10.1093/mnras/stt1831), Monthly Notices of the Royal Astronomical Society, Volume 436, Issue 4, 21 December 2013, Pages 3547–3556
:::
