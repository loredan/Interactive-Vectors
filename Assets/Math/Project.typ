#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[var c = Vector3.Project(a, b);]

#set text(size: 18pt)
$frac(#text(fill: green)[$overline(b)$], |#text(fill: green)[$overline(b)$]|) dot (#text(fill: red)[$overline(a)$] dot frac(#text(fill: green)[$overline(b)$], |#text(fill: green)[$overline(b)$]|)) = #text(fill: blue)[$overline(c)$]$