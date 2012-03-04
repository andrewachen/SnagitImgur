makecert -r -pe -n "CN=NOT TechSmith" -ss CA -sr CurrentUser -a sha1 -sky signature -sv NotTechSmith.pvk NotTechSmith.cer
certutil -user -addstore Root NotTechSmith.cer
makecert -pe -n "CN=NOT TechSmith" -a sha1 -sky signature -ic NotTechSmith.cer -iv NotTechSmith.pvk -sv NotTechSmith.pvk NotTechSmith.cer
pvk2pfx -pvk NotTechSmith.pvk -spc NotTechSmith.cer -pfx NotTechSmith.pfx
signtool sign /v /f NotTechSmith.pfx ..\build\Release\{EDA9F1DD-85B9-44F6-9D3C-125B2DD1109D}\SnagitImgur.dll