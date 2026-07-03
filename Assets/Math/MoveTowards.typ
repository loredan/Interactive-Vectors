#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[var c = Vector3.MoveTowards(a, b, t);]

#set text(size: 18pt)
$#text(fill: red)[$overline(a)$] + frac(#text(fill: green)[$overline(b)$] - #text(fill: red)[$overline(a)$], |#text(fill: green)[$overline(b)$] - #text(fill: red)[$overline(a)$]|) dot "min"(t, |#text(fill: green)[$overline(b)$] - #text(fill: red)[$overline(a)$]|) = #text(fill: blue)[$overline(c)$]$