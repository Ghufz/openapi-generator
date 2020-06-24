#
# OpenAPI Petstore
# This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.
# Version: 1.0.0
# Generated by OpenAPI Generator: https://openapi-generator.tech
#

<#
.SYNOPSIS

No summary available.

.DESCRIPTION

A category for a pet

.PARAMETER Id
No description available.
.PARAMETER Name
No description available.
.OUTPUTS

Category<PSCustomObject>
#>

function Initialize-PSCategory {
    [CmdletBinding()]
    Param (
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = $true)]
        [System.Nullable[Int64]]
        ${Id},
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = $true)]
        [ValidatePattern("^[a-zA-Z0-9]+[a-zA-Z0-9\\.\\-_]*[a-zA-Z0-9]+$")]
        [String]
        ${Name}
    )

    Process {
        'Creating PSCustomObject: PSPetstore => PSCategory' | Write-Debug
        $PSBoundParameters | Out-DebugParameter | Write-Debug

		
		$PSO = [PSCustomObject]@{
            "id" = ${Id}
            "name" = ${Name}
        }
	

        return $PSO
    }
}

<#
.SYNOPSIS

Convert from JSON to Category<PSCustomObject>

.DESCRIPTION

Convert from JSON to Category<PSCustomObject>

.PARAMETER Json

Json object

.OUTPUTS

Category<PSCustomObject>
#>
function ConvertFrom-PSJsonToCategory {
    Param(
        [AllowEmptyString()]
        [string]$Json
    )

    Process {
        'Converting JSON to PSCustomObject: PSPetstore => PSCategory' | Write-Debug
        $PSBoundParameters | Out-DebugParameter | Write-Debug

        $JsonParameters = ConvertFrom-Json -InputObject $Json

        # check if Json contains properties not defined in PSCategory
        $AllProperties = ("id", "name")
        foreach ($name in $JsonParameters.PsObject.Properties.Name) {
            if (!($AllProperties.Contains($name))) {
                throw "Error! JSON key '$name' not found in the properties: $($AllProperties)"
            }
        }

        if (!([bool]($JsonParameters.PSobject.Properties.name -match "id"))) { #optional property not found
            $Id = $null
        } else {
            $Id = $JsonParameters.PSobject.Properties["id"].value
        }

        if (!([bool]($JsonParameters.PSobject.Properties.name -match "name"))) { #optional property not found
            $Name = $null
        } else {
            $Name = $JsonParameters.PSobject.Properties["name"].value
        }

        $PSO = [PSCustomObject]@{
            "id" = ${Id}
            "name" = ${Name}
        }

        return $PSO
    }

}

