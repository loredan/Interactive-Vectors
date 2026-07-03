#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[
  t += speed \* Time.deltaTime;

  var c = Vector3.Lerp(a, b, t);
]