$path = "./TP CAI 1C2026/Forms/Datos/Guias.json"
$json = Get-Content -Raw -Path $path | ConvertFrom-Json

foreach ($g in $json) {
	# Skip if Historial already has entries
	if ($g.Historial -and $g.Historial.Count -gt 0) { continue }
	$fecha = [datetime]::Parse($g.FechaImposicion)
	$d0 = $fecha.ToString('yyyy-MM-dd')
	$d1 = $fecha.AddDays(1).ToString('yyyy-MM-dd')
	$d2 = $fecha.AddDays(2).ToString('yyyy-MM-dd')
	$d3 = $fecha.AddDays(3).ToString('yyyy-MM-dd')

	$finalEstado = $g.Estado

	$hist = @()
	$hist += @{ Fecha = $d0; Estado = 2 }
	$hist += @{ Fecha = $d0; Estado = 4 }
	$hist += @{ Fecha = $d0; Estado = 5 }
	$hist += @{ Fecha = $d0; Estado = 6 }

	$hist += @{ Fecha = $d1; Estado = 8 }
	$hist += @{ Fecha = $d1; Estado = 9 }
	$hist += @{ Fecha = $d1; Estado = 10 }

	$hist += @{ Fecha = $d2; Estado = 11 }
	$hist += @{ Fecha = $d2; Estado = 12 }
	$hist += @{ Fecha = $d2; Estado = 14 }

	$hist += @{ Fecha = $d3; Estado = $finalEstado }

	$g.Historial = $hist
}

# Write back with indentation
$json | ConvertTo-Json -Depth 10 | Out-File -FilePath $path -Encoding utf8
Write-Host "Guias.json actualizado: historial generado para entradas vacías."