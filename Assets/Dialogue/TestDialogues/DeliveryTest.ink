VAR hasDeliveryItem = false
VAR action = false

do you have a gender change potion for me?
{hasDeliveryItem: ->yes |->no}

===yes===
* [yes]
Ah, thank you! just what i needed *transitions aggressively*
~setAction()
->END

===no===
* [no]
Oh, ok, could you come back if you get one?
->END

===function setAction()===
~action = true 