::: danger DRAFT
This text is an incomplete draft in progress.
:::

::: info Abstract
Every star system needs a star, but how do we choose one?

---

We develop an interactive star selector inspired by [Hertzsprung–Russell Diagram](https://en.wikipedia.org/wiki/Hertzsprung%E2%80%93Russell_diagram).
Selection is based on [luminosity](https://en.wikipedia.org/wiki/Luminosity) and [effective temperature](https://en.wikipedia.org/wiki/Effective_temperature) that determine type, class, radius, and other characteristics of a star.

We use [analytic geometry](https://en.wikipedia.org/wiki/Analytic_geometry) to simplify selector implementation.

[Read theory and background story](../stars/index.md).
:::

## Selector Mechanics

![](hertzsprung-russell-diagram.png){style=float:right;margin-top:-10px;width:350px}
**Hertzsprung-Russel Diagram** provides an intuitive way of mapping all theoretically possible stars to an area constrained by a rectangle,
with $(x,y)$ coordinates corresponding to a unique pairing of temperature ($x$) and luminosity ($y$).

$(x,y)$ pairs corresponding to valid combinations form irregular shapes surrounded with empty space "filled" with values not observed in nature.

In very simple terms:

::: info Explain Like I'm 5
**Star selector** will work by accepting points inside coloured shapes while rejecting black points. 
:::

### :mag_right: How to check if point $(x,y)$ is selectable?

We could reduce problem to finding colour of a pixel pointed by mouse, preventing selection when pixel is black, enabling it otherwise.
**Simple solution to a simple problem**, but before we code let's pretend that we've implemented it already and look one step ahead.

### :mag_right: How to check class of a selected star?

In other words, how to find if star is a _White Dwarf_?

This is a harder problem that cannot be solved easily by looking at individual pixels. We would need to find if a pixel belongs to a group of many pixels corresponding to a region labeled a _White Dwarfs_...
_There must be a better way!_

**There is a better way.**

## [Analytic Geometry](https://en.wikipedia.org/wiki/Analytic_geometry)

::: info 🎵 [Edna St. Vincent Millay](https://en.wikisource.org/wiki/The_Harp-Weaver/Euclid_alone_has_looked)
![](euclid.png){style=float:left;width:90px;margin-top:3px;margin-right:10px;}

_[Euclid](https://en.wikipedia.org/wiki/Euclid) alone  
Has looked on Beauty bare. Fortunate they  
Who, though once only and then but far away,     
Have heard her_
:::

We start by verifying assumptions to improve chances of solving the problem we actually set out to solve.
The only relevant assumption is [ASS-04: Stars class O and M do not host habitable systems](../stars/index.md#ass-04), we satisfy it by cutting away `O|M` bands from both sides of the diagram.

![](simple-hr.png){style=float:right;width:350px}

Next we simplify shapes and reduce "fuzziness" of class boundaries by approximating them with non-overlapping ellipses covering all selectable points.

We are on the verge of creating our very first mathematical model,
a kind of [abstraction](https://en.wikipedia.org/wiki/Abstraction) describing original problem using four rotated, non-overlapping ellipses on a plane,
each encapsulating an **infinite set of points** corresponding to all possible stars of a specific class.

When rendered on a screen with some resolution, ellipses become _"finite"_ with each having number of elements corresponding exactly to a number of pixels covering their area on screen.

This perspective simplifies all aspects of the problem to just one simple question.

### :mag_right: How to check if point $(x,y)$ belongs to a specific ellipse?

![](general-ellipse.png){style=float:right}

All points inside boundary of a general ellipse satisfy:

$\dfrac {X^2}{a^2} + \dfrac {Y^2}{b^2} \le 1$

We use [Euclidean transformation](https://en.wikipedia.org/wiki/Rigid_transformation) to express $(X,Y)$ in terms of _Cartesian coordinates $(x,y)$_, _center point of ellipse $(x_0, y_0)$_ and _angle of rotation $\theta$_:

$X=(y-y_0)sin\theta+(x-x_0)cos\theta$
$Y=(y-y_0)cos\theta-(x-x_0)sin\theta$

::: info References
---


:::