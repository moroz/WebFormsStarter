[CmdletBinding()]
param(
    [string]$Old = "WebFormsStarter",

    [Parameter(Mandatory=$true)]
    [string]$New,

    [string]$Path = "."
)

Write-Host "Replacing pattern in files..."
Get-ChildItem -Recurse -File | Where-Object {
    Select-String -Pattern $Old -Path $_.FullName
} | ForEach-Object {
    (Get-Content $_.FullName) -replace $Old, $New | Set-Content $_.FullName
}

Write-Host "Replacing pattern in directory names..."
Get-ChildItem -Recurse -Directory |
    Sort-Object FullName -Descending |
    Where-Object { $_.Name -match $Old } |
    ForEach-Object {
        $newName = $_.Name -replace $Old, $New
        $newPath = Join-Path $_.Parent.FullName $newName
        Rename-Item -Path $_.FullName -NewName $newPath
    }

Write-Host "Replacing pattern in file names..."
Get-ChildItem -Recurse -File |
    Where-Object { $_.Name -match $Old } |
    ForEach-Object {
        $newName = $_.Name -replace $Old, $New
        $newPath = Join-Path $_.DirectoryName $newName
        Rename-Item -Path $_.FullName -NewName $newPath
    }
