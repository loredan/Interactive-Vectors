#set page(fill: none, width: auto, height: auto, margin: 10pt)
#set text(fill: white)

#text(font: "JetBrains Mono", size: 14pt)[var c = Vector3.RotateTowards(a, b, t, k);]

#set text(size: 18pt)
$#text(fill: red)[$vec(rho_a, theta_a)$] + vec("min"(#text(fill: green)[$rho_b$] - #text(fill: red)[$rho_a$], k), "min"(#text(fill: green)[$theta_b$] - #text(fill: red)[$theta_a$], t)) = #text(fill: blue)[$vec(rho_c, theta_c)$]$