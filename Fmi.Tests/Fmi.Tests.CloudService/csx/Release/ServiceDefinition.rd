<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Fmi.Tests.CloudService" generation="1" functional="0" release="0" Id="7d7316b4-f615-4c1d-841b-f40872c4cb21" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Fmi.Tests.CloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Fmi.Tests.Api.Services:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/LB:Fmi.Tests.Api.Services:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Fmi.Tests.Api.Services:testsConnection" defaultValue="">
          <maps>
            <mapMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/MapFmi.Tests.Api.Services:testsConnection" />
          </maps>
        </aCS>
        <aCS name="Fmi.Tests.Api.ServicesInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/MapFmi.Tests.Api.ServicesInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Fmi.Tests.Api.Services:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.Services/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapFmi.Tests.Api.Services:testsConnection" kind="Identity">
          <setting>
            <aCSMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.Services/testsConnection" />
          </setting>
        </map>
        <map name="MapFmi.Tests.Api.ServicesInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.ServicesInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Fmi.Tests.Api.Services" generation="1" functional="0" release="0" software="C:\Git-Repos\FMI-WebDev2015\Fmi.Tests\Fmi.Tests.CloudService\csx\Release\roles\Fmi.Tests.Api.Services" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="testsConnection" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Fmi.Tests.Api.Services&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Fmi.Tests.Api.Services&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.ServicesInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.ServicesUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.ServicesFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="Fmi.Tests.Api.ServicesUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="Fmi.Tests.Api.ServicesFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Fmi.Tests.Api.ServicesInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="263e77a9-fd19-4d9d-a19a-bdf0bb42f3ae" ref="Microsoft.RedDog.Contract\ServiceContract\Fmi.Tests.CloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="d688700d-2ec8-493d-99e9-2b304b86e477" ref="Microsoft.RedDog.Contract\Interface\Fmi.Tests.Api.Services:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.Services:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>