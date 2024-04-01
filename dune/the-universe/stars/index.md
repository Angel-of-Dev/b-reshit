::: info Abstract
It should come as no surprise that local star is the primary source of energy on a hot desert planet,
but how much of that energy actually reaches the surface and how can we model the flow of that energy through time and space?

We look at [spectral classification of stars](https://en.wikipedia.org/wiki/Stellar_classification)
to explore the impact of **size** and **temperature** on the amount of **energy** they produce per unit of time. 
We model the star as a [blackbody](https://en.wikipedia.org/wiki/Black_body) and use [Stefan-Boltzmann Law](https://en.wikipedia.org/wiki/Stefan%E2%80%93Boltzmann_law) to compute power output as [Luminosity](https://en.wikipedia.org/wiki/Luminosity).

:::

## A Very Particular Star

::: tip 🔰 Lore
![](star.png){style=float:right}

[**Arrakis**, the planet known as Dune; third planet of Canopus](#dune-01), the second-brightest star of Earth's sky.
Located over 300 light-years away in constellation of [Carina](https://en.wikipedia.org/wiki/Carina_(constellation)), it belongs to the keel of [Argo Navis](https://en.wikipedia.org/wiki/Argo_Navis),
a celestial group named after the ship sailed by [Jason](https://en.wikipedia.org/wiki/Jason) and [Argonauts](https://en.wikipedia.org/wiki/Argonauts).

Ancient peoples told stories involving [Canopus](https://en.wikipedia.org/wiki/Canopus) and its heavenly "twin" [Sirius](https://en.wikipedia.org/wiki/Sirius)
long before they preserved their names in writing [on a slab of clay in 1100 BCE](#ref-01).

Even older are the stories captured in [Vedic Sanskrit hymns](https://en.wikipedia.org/wiki/Vedic_Sanskrit) of [Rigveda](https://en.wikipedia.org/wiki/Rigveda)
in which sage [Agastya](https://en.wikipedia.org/wiki/Agastya),
"the one who illuminates", [crossed to the southern part the Vindhya mountains where he saw Canopus for the very first time](#ref-08). 
Years later the star became visible from most of India,
but in times of Agastya it stayed low in the sky and could only be seen from the south.
[Astronomical dating assessed that Canopus was hiding from northern latitudes until circa 4000 BCE](#ref-05),
solidifying its place as a "literal star" of one of the oldest legends.

For longer than can be remembered Canopus outshone every object in the sky, until the time when Sirius, the star of stars, moved towards Earth and
[rose in the dark, the brightest of all, evil portent bringing heat and fevers to suffering humanity](#ref-04).
Its perpetual fire burning on celestial altar for [200,000 years before Earth can escape its suffocating grip,
allowing Canopus to once again dominate the darkness of the night](#ref-06).

![](const.png){style=float:right}

Still, it's the Canopus, ["The One Who Points the Way"](#dune-01) that [Bedouin of Sinai and desert dwellers before them used to navigate dunes](#ref-07). 

Those who eventually settled [aligned their temples to the rising star](#ref-02),
while restless nomads combed through desert of the barren space, bringing with them [Canopus Star Trackers](#ref-03) to illuminate the way
towards verdant oasis they believed awaited them across the universe.

[When God hath ordained a creature to die in a particular place, He causeth that creature’s wants to direct him to that place](#dune-03).
And so they found **Arrakis**.
:::

Observations from Earth describe Canopus as a giant star much larger and more bright than Sun.

It has exhausted its core hydrogen and evolved away from [main sequence](https://en.wikipedia.org/wiki/Main_sequence). 
It does not have enough mass to collapse into [neutron star](https://en.wikipedia.org/wiki/Neutron_star) or [black hole](https://en.wikipedia.org/wiki/Black_hole), but is evolving into [white dwarf](https://en.wikipedia.org/wiki/White_dwarf).


| Star        | Mass [M☉] | Radius [R☉] | Luminosity [L☉] | Temperature [K] | Spectral Class |
|-------------|-----------|-------------|-----------------|-----------------|----------------|
| **Canopus** | 8         | 73          | 10,700          | 7,400           | A              |
| **Sun**     | 1         | 1           | 1               | 5,700           | G              |

::: info Solar Units
Mass, radius and luminosity are expressed in solar units relative to the Sun.

| Symbol | Unit             | Value                                                         |
|--------|------------------|---------------------------------------------------------------|
| **M☉** | Solar Mass       | $1.988 \cdot 10^{30}$ kg                                      |
| **R☉** | Solar Radius     | $6.957 \cdot 10^8$ m                                          |
| **L☉** | Solar Luminosity | $3.828 \cdot 10^{26}$ [W](https://en.wikipedia.org/wiki/Watt) |
:::

:mag_right: What does it tell us about **Arrakis** and how does **giant star system** compare to a more familiar [Solar System](https://en.wikipedia.org/wiki/Solar_System)? 

## Spectral Classification

Stars produce an enormous amount of [electromagnetic radiation](https://en.wikipedia.org/wiki/Electromagnetic_radiation) 
consisting of waves propagating through space at the [speed of light](https://en.wikipedia.org/wiki/Speed_of_light) as a stream of [photons](https://en.wikipedia.org/wiki/Photon) carrying [radiant energy](https://en.wikipedia.org/wiki/Radiant_energy).

Characteristics of electromagnetic radiation are organised by wavelengths into [electromagnetic spectrum](https://en.wikipedia.org/wiki/Electromagnetic_spectrum).
The spectrum is further divided into bands that group waves based on how they are produced, how they interact with matter and by their practical applications.

We focus on two bands produced by stars:
* [Visible Light](https://en.wikipedia.org/wiki/Visible_spectrum), that we evolved to see
* [Ultraviolet (UV) Light](https://en.wikipedia.org/wiki/Ultraviolet), required to produce essential for life [vitamin D](https://en.wikipedia.org/wiki/Vitamin_D), while at the same time destroys [DNA](https://en.wikipedia.org/wiki/DNA) without which life cannot function

![](em-spectrum.png)

::: info Wavelength ($\lambda$), frequency ($f$) and photon energy ($E$)
![](wavelength-frequency-energy.png){style=float:right;margin-left:40px}

Wavelength ($\lambda$) is inversely correlated to frequency ($f$) and energy ($E$).

**Radio Waves** are **long and weak** compared to **Gamma Rays** that are **short and strong**.
:::

### :mag_right: What is the impact of temperature on electromagnetic radiation?

**Cooler stars** reach peak radiation intensity at **lower energy**.  
**Warmer stars** reach peak radiation intensity at **higher energy**.

![](black-body-radiation.png)

**Sun**, being cooler, radiates strongly with waves from **visible part of spectrum**.  
**Canopus**, being warmer, radiates strongly with waves from  **UV part of spectrum**.

This relationship is used to [classify stars based on their temperatures](https://en.wikipedia.org/wiki/Stellar_classification).  

![](stellar-classification.png)

| Star        | Temperature [K] | Spectral Class |
|-------------|-----------------|----------------|
| **Canopus** | 7,400           | A              |
| **Sun**     | 5,700           | G              |

Dark gaps in otherwise continuous spectrum are caused by emission and absorption of photons by atoms and molecules.
Those [spectral lines](https://en.wikipedia.org/wiki/Spectral_line) are used to [identify chemical composition](https://en.wikipedia.org/wiki/Spectral_line#Visible_light) of a star.

## Measure of Electromagnetic Radiation

Electromagnetic energy emitted by a star is measured as [Luminosity](https://en.wikipedia.org/wiki/Luminosity) determined from its size and [effective temperature](https://en.wikipedia.org/wiki/Effective_temperature)
using [Stefan-Boltzmann Law](https://en.wikipedia.org/wiki/Stefan%E2%80%93Boltzmann_law) and [blackbody](https://en.wikipedia.org/wiki/Black_body) approximation.

::: info Blackbody
A hypothetical object imagined as:
* a **hollow sphere**
  * with radius $R$
  * centered at point source of light $S$
    ![](hollow-sphere.png)

* an **ideal absorber**
  * absorbs all light from all angles
  * does not reflect any light

* an **ideal emitter**
  * emitted energy depends only on body's temperature (Stefan-Boltzmann Law)
  * uniformly illuminates whole surface in all directions, with no energy lost through the body
    ![](blackbody.png)
  * emits a continuous spectrum of light (no spectral lines)
    ![](visible-light-spectrum.png)
:::

**Stefan-Boltzmann Law** states that energy radiated by **blackbody** per unit of time is directly proportional to the fourth power of its **effective temperature**.

::: tip Energy radiated by an object
$E=\sigma T^{4}$

where:
* $T$, the effective temperature, expressed in **Kelvin [$K$]**
* $\sigma=5.67 \cdot 10^{-8}$, the **Stefan–Boltzmann Constant** expressed as [$W \cdot m^{-2} \cdot K^{-4}$]
:::

::: info Effective Temperature
Effective temperature of a celestial body is the temperature of a **blackbody** that would emit the same total amount of electromagnetic radiation.
:::

**Luminosity**, the measure of object's **power output**, is calculated by multiplying energy of a blackbody by its surface area $A$:

$L=AE=A\sigma T^{4}$

Approximating shape of a star as sphere with area $4 \pi R^{2}$ we see that luminosity depends on on objects radius.
As radius increases the surface area also increases leading to increase in luminosity.

::: tip Luminosity of a spherical object
$L=(4 \pi R^{2}) \sigma T^{4}$
:::

### :mag_right: How does Canopus and Sun compare to other stars?

The relationship between luminosity, temperature and spectrum class is visualised below on a modified [Hertzsprung–Russell Diagram](#ref-10).
Solar mass and radii of several stars added for reference.

![](hertzsprung-russell-diagram.png)

### Extreme Star Systems

We consider stars of class O andM to be extreme and unlikely to host habitable planets.

Class M stars are very likely to contain planets that are tidally locked. The effect would be similar to that of Earth and its Moon which is tidally locked and always faces the same side towards Earth.
While it generally isn't a problem in case of a moon, [a tidally locked planet is unlikely to sustain any form of life due to disrupted day/night cycles resulting in extreme temperatures](#ref-11).

::: tip Assumptions
###### :a: ASS-04: Stars class O and M do not host habitable systems.{#ASS-04}
Those stars are out of scope of the model.
:::

::: info References
---
###### DUNE-01
Herbert, Frank (1965). "Dune", [p. 628](https://archive.org/details/frank-herberts-dune-saga-collection-books-1-6-by-frank-herbert/page/n627/mode/2up?q="Canopus")

_"Arrakis, the planet known as Dune; third planet of Canopus"_

###### DUNE-02
Herbert, Frank (1965). "Dune", [p.256](https://archive.org/details/frank-herberts-dune-saga-collection-books-1-6-by-frank-herbert/page/n255/mode/2up?q=%22The+One+Who+Points+the+Way%22)  

_"The One Who Points the Way"_

###### DUNE-03
Herbert, Frank (1965). "Dune", [p. 166](https://archive.org/details/frank-herberts-dune-saga-collection-books-1-6-by-frank-herbert/page/n165/mode/2up?q=%22When+God+hath+ordained%22)  

_"Paul spoke dryly: “A terrible place for them to die.”  
Without turning, Kynes said: When God hath ordained a creature to die in a particular place, He causeth that creature’s wants to direct him to that place."_

###### REF-01
Rogers, John H. (1998). ["Origins of the Ancient Constellations: I. The Mesopotamian Traditions"](https://articles.adsabs.harvard.edu/pdf/1998JBAA..108....9R). Journal of the British Astronomical Association. 108 (1): 9–28.

###### REF-02
George Nicholas Atiyeh (1 January 1995). [The Book in the Islamic World: The Written Word and Communication in the Middle East](https://books.google.com/books?id=t4LEfpCW_kQC). SUNY Press. ISBN 978-0-7914-2473-5.  
Cited by [Wikipedia:Canopus](https://en.wikipedia.org/wiki/Canopus#Role_in_navigation)  

_"The southeastern wall of the Kaaba_ 🕋 _in Mecca is aligned with the rising point of Canopus"_
###### REF-03
[Wikipedia:Canopus](https://en.wikipedia.org/wiki/Canopus#Role_in_navigation)  

_"Many spacecraft carry a special camera known as a Canopus [Star Tracker](https://en.wikipedia.org/wiki/Star_tracker)"_

###### REF-04
Homer (1997). Iliad. Trans. Stanley Lombardo. ISBN 978-0-87220-352-5. 22.33–37  

_"Sirius rises late in the dark, liquid sky  
On summer nights, star of stars,  
Orion's Dog they call it, brightest  
Of all, but an evil portent, bringing heat  
And fevers to suffering humanity."_

###### REF-05
Abhyankar, K. D. [“Folklore and Astronomy: Agastya a Sage and a Star”](http://www.jstor.org/stable/24111087), Current Science 89, no. 12 (2005): 2174–76

K Chandra Hari, ["On the Visibility of Agastya (Canopus) in India"](https://cahc.jainuniversity.ac.in/assets/ijhs/Vol51_2016_3_Art06.pdf), Indian Journal of History of Science, 51.3 (2016) 511-520

###### REF-06
Tomkin, Jocelyn (April 1998). ["Once and Future Celestial Kings"](https://www.thefreelibrary.com/Once+and+future+celestial+kings.-a020468305). Sky and Telescope.  

###### REF-07
[Wikipedia:Canopus](https://en.wikipedia.org/wiki/Canopus#Role_in_navigation)  

_"The [Bedouin](https://en.wikipedia.org/wiki/Negev_Bedouin) people of the Negev and [Sinai](https://en.wikipedia.org/wiki/Sinai_Peninsula) knew Canopus as Suhayl, and used it and Polaris as the two principal stars for navigation at night."_

###### REF-08
[Complete Rig Veda in English (Sakala Shakha)](https://archive.org/details/rigvedacomplete/page/n225/mode/2up?q=Canopus)  

_"He is one of those indefinable mythic personages who are found in the ancient traditions of many nations,
and in whom cosmogonical or astronomical notions are generally figured.  
Thus it is related of Agastya that the Vindhyan mountains prostrated themselves before him; and yet the same Agastya is believed to be the regent of the star Canopus."_

###### REF-09
* Pablo Carlos Budassi, [Stellar Classification Chart](https://en.wikipedia.org/wiki/File:Stellar_Classification_Chart.png)

###### REF-10
* European Southern Observatory (ESO), [Hertzsprung–Russell Diagram](https://www.eso.org/public/images/eso0728c/)

###### REF-11
* Ashok K. Singal, [Life on a tidaly locked planet](https://arxiv.org/ftp/arxiv/papers/1405/1405.1025.pdf), Planex Newsletter, Vol. 4, Issue 2, 8 (2014)
:::