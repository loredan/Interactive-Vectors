#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[
  var c = a.normalized;

  or

  Vector3.Normalize(a);
]

#set text(size: 18pt)
$frac(#text(fill: red)[$overline(a)$], |#text(fill: red)[$overline(a)$]|) = #text(fill: blue)[$overline(c)$]$