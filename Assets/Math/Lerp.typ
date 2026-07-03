#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[var c = Vector3.Lerp(a, b, t);]

#set text(size: 18pt)
$#text(fill: red)[$overline(a)$] + t(#text(fill: green)[$overline(b)$] - #text(fill: red)[$overline(a)$]) = #text(fill: blue)[$overline(c)$], 0 <= t <= 1$