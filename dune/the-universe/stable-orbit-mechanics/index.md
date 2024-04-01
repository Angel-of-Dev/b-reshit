# Mechanics of Stable Orbits

::: info Abstract
We look for model parameters that result in a star system where all celestial bodies follow stable orbits.
We use [Sphere of Influence](https://en.wikipedia.org/wiki/Sphere_of_influence_(astrodynamics)) and [Roche Limit](https://en.wikipedia.org/wiki/Roche_limit) to specify maximum and minimum length of orbit radius.
We introduce **Moon Stability Criterion** to determine minimum distance between two moons.
:::

## Sphere of Influence

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


## Radius of Influence of Arrakis

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

Astronomical Unit also simplifies model parametrization by requiring only a single parameter `Astronomical Unit Length` expressed in absolute terms and relating other distances to it in a form or ratios.
:::

:mag_right: We know the maximum, but what about a minimum distance between a planet and its moon?

## Roche Limit

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
* $r=1 \cdot 10^{-5}$ AU, the approximate radius of Moon (~1700 km)

::: tip [4] Roche limit of smaller moon
$D_{Moon} \approx 1 \cdot 10^{-5} \cdot \sqrt [3] {2 \cdot \dfrac {6 \cdot 10^{24}}{7 \cdot 10^{22}}}\approx 0.0000555 \approx 5.55 \cdot 10^{-5}$ AU
:::

The minimum distance between center of Arrakis and center of its smaller moon is $5.55 \cdot 10^{-5}$ AU.

:mag_right: That's good to know, but what about a minimum distance between the moons?

## Moon Stability Criterion

Consider the following setup:
![](circular-orbit-moon-instability-regions.png)

where:
* $M$, the mass of the planet
* $m_i$, the mass of $i$-th moon
* $r_i$, the radius of $i$-th moon orbit

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

Next we could calculate maximum allowed mass of the second moon and a radius of its orbit, but we stop discovery here and shift attention elsewhere.

---
::: details References
* Seefelder, Wolfgang (2002). [Lunar Transfer Orbits Utilizing Solar Perturbations and Ballistic Capture](https://www.google.co.uk/books/edition/Lunar_Transfer_Orbits_Utilizing_Solar_Pe/NVg_vYHePt0C). Munich: Herbert Utz Verlag. p. 76. ISBN 3-8316-0155-0
* C. A. Giuppone, M. H. M. Morais, A. C. M. Correia, [A semi-empirical stability criterion for real planetary systems with eccentric orbits](https://doi.org/10.1093/mnras/stt1831), Monthly Notices of the Royal Astronomical Society, Volume 436, Issue 4, 21 December 2013, Pages 3547–3556
  :::
