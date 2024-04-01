::: info Abstract
![](eclipse.png){style=float:right;margin-top:-20px;margin-right:-20px}
We explore details behind **solar eclipses** and remind ourselves why Moon and Sun appear to be almost the same size in the sky.  
It might seem like a minor detail that we could skip, but the theory behind it will prove to be very useful later.

We assume alignment of [orbital planes](https://en.wikipedia.org/wiki/Orbital_plane) to make [total solar eclipses](https://en.wikipedia.org/wiki/Solar_eclipse) more predictable. 
We look at "apparent size" of celestial bodies in the sky and describe it mathematically with [angular diameter](https://en.wikipedia.org/wiki/Angular_diameter#Use_in_astronomy).
We introduce **Total Eclipse Criterion** to check if model parameters make total eclipses possible. 
:::

## Total Eclipse

On Earth, [total solar eclipse](https://en.wikipedia.org/wiki/Solar_eclipse) happens when when Moon fully obstructs the view of Sun. This phenomenon occurs somewhere on Earth every several months, but very rarely in the same place.
This is because Moon's and Earth's orbits are not perfectly circular and their orbital planes are not perfectly aligned.

![](angular-diameter-3.png)

Our model already assumes perfectly circular orbits [:a:[ASS-02](../index.md#celestial-neighbourhood)] but it does not say much about orbital planes. Let's do that now.

::: tip Assumptions
:a: **ASS-03: Aligned orbital planes.**  
[Orbital planes](https://en.wikipedia.org/wiki/Orbital_plane) of all celestial bodies are aligned.
:::

This assumption ensures that eclipses can be observed regularly from the same place on a planet.

## Point of View and Apparent Size

Not every planet with a moon experiences eclipses, many never do. For example, when moon is too small or too far away,
its apparent size (as seen from the planet's surface) is smaller than the apparent size of the star, making eclipses impossible.

This "apparent size" can be described mathematically as [angular diameter](https://en.wikipedia.org/wiki/Angular_diameter#Use_in_astronomy):

$\delta \approx \dfrac {2R}{d}$

where:
* $\delta$, the apparent size of distant object, here expressed in [radians](https://en.wikipedia.org/wiki/Radian)
* $R$, the radius of distant object
* $d$, the distance of the object from observer

![](angular-diameter-1.png)

**Apparent size** is normally expressed in [arcseconds](https://en.wikipedia.org/wiki/Minute_and_second_of_arc)
instead of [radians](https://en.wikipedia.org/wiki/Radian) and this is also how we will express it from now on, approximating $1$ radian as $2.06 \cdot 10^5$ arcseconds:

$\delta \approx 2.06 \cdot 10^5 \cdot \dfrac {2R}{d}$ **arcseconds**

Setting parameters with values from our solar system:
* $R=698,252,813$ meters, radius of Sun
* $d=1.5 \cdot 10^{11}$ meters, distance from Earth to Sun

![](angular-diameter-2.png)

::: tip [8] Apparent Size of Sun
$\delta_{Sun} \approx 2.06 \cdot 10^5 \cdot \dfrac {2R}{d} \approx 2.06 \cdot 10^5 \cdot \dfrac {2 \cdot 698,252,813}{1.5 \cdot 10^{11}} \approx 1,918$ **arcseconds**
:::

and for the Moon:
* $R=1,713,966$ meters, radius of Moon
* $d=3.84 \cdot 10^{8}$ meters, distance from Earth to Moon

::: tip [9] Apparent Size of Moon
$\delta_{Moon} \approx 2.06 \cdot 10^5 \cdot \dfrac {2R}{d} \approx 2.06 \cdot 10^5 \cdot \dfrac {2 \cdot 1,713,966}{3.84 \cdot 10^{8}} \approx 1,832$ **arcseconds**
:::

## Total Eclipse Criterion

Total eclipses are always possible when Moon seems bigger than the Sun ($\delta_{Moon} \ge \delta_{Sun}$) but since human eye can only resolve diameters of approximately 1 arcminute (60 arcseconds), it seems reasonable to allow some margin of error for the criterion. We'll use 2 arcminutes (120 arcseconds) for a good measure.

::: tip [10] Total Eclipse Possibility Criterion
$\text{ Total Eclipse Possible} = \begin{cases}
true  & \delta_{Moon} \ge -120+\delta_{Sun}  \\
false & \text{ otherwise}
\end{cases}$
:::

Substituting previously calculated values the criterion correctly predicts that total eclipse is possible:

$\delta_{Moon} \ge -120+\delta_{Sun}$  
$1832 \ge -120+1918$  
$1832 \ge 1798$

---
::: details References
* Michael A. Seeds; Dana E. Backman (2010). [Stars and Galaxies (7 ed.)](https://www.google.co.uk/books/edition/Foundations_of_Astronomy/Cf82ygAACAAJ?hl=en). Brooks Cole. ISBN 978-0-538-73317-5.
  :::