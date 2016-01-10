<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Fmi.Tests.CloudService" generation="1" functional="0" release="0" Id="db2abaa1-8f63-4d3b-8f5d-7d90c70638c6" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Fmi.Tests.CloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Fmi.Tests.Api.Services:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/LB:Fmi.Tests.Api.Services:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="RestTestWebApp:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/LB:RestTestWebApp:Endpoint1" />
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
        <aCS name="RestTestWebApp:ApiBaseUrl" defaultValue="">
          <maps>
            <mapMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/MapRestTestWebApp:ApiBaseUrl" />
          </maps>
        </aCS>
        <aCS name="RestTestWebAppInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/MapRestTestWebAppInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Fmi.Tests.Api.Services:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.Services/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:RestTestWebApp:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebApp/Endpoint1" />
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
        <map name="MapRestTestWebApp:ApiBaseUrl" kind="Identity">
          <setting>
            <aCSMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebApp/ApiBaseUrl" />
          </setting>
        </map>
        <map name="MapRestTestWebAppInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebAppInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Fmi.Tests.Api.Services" generation="1" functional="0" release="0" software="C:\Git-Repos\FMI-WebDev2015\Fmi.Tests\Fmi.Tests.CloudService\csx\Debug\roles\Fmi.Tests.Api.Services" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="testsConnection" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Fmi.Tests.Api.Services&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Fmi.Tests.Api.Services&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;RestTestWebApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
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
        <groupHascomponents>
          <role name="RestTestWebApp" generation="1" functional="0" release="0" software="C:\Git-Repos\FMI-WebDev2015\Fmi.Tests\Fmi.Tests.CloudService\csx\Debug\roles\RestTestWebApp" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="8080" />
            </componentports>
            <settings>
              <aCS name="ApiBaseUrl" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;RestTestWebApp&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Fmi.Tests.Api.Services&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;RestTestWebApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebAppInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebAppUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebAppFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="Fmi.Tests.Api.ServicesUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="RestTestWebAppUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="Fmi.Tests.Api.ServicesFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="RestTestWebAppFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Fmi.Tests.Api.ServicesInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="RestTestWebAppInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="59401113-6bb9-4c55-8966-0c70632b0d11" ref="Microsoft.RedDog.Contract\ServiceContract\Fmi.Tests.CloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="45c24410-0c7e-42fd-b7e6-fb3f6633df09" ref="Microsoft.RedDog.Contract\Interface\Fmi.Tests.Api.Services:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/Fmi.Tests.Api.Services:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="239f27fb-cfa1-44e3-a32b-475198117c3c" ref="Microsoft.RedDog.Contract\Interface\RestTestWebApp:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Fmi.Tests.CloudService/Fmi.Tests.CloudServiceGroup/RestTestWebApp:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>