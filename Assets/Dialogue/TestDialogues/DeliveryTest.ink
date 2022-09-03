VAR hasDeliveryItem = false
VAR action = false

do you have the item we need?
{hasDeliveryItem: ->yes |->no}

===yes===
* [yes]
Ah, thank you! just what i needed
~setAction()
->END

===no===
* [no]
Oh, ok, could you come back when you do?
->END

===function setAction()===
~action = true 