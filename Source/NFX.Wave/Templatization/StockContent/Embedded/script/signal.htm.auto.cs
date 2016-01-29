//WARNING: This code was auto generated by template compiler, do not modify by hand!
//Generated on 29.01.2016 20:59:49 by NFX.Templatization.TextCSTemplateCompiler at SAMSON

using System; 
using System.Text; 
using System.Linq; 
using System.Collections.Generic; 

namespace id_4062_template_371 
{

 ///<summary>
 /// Auto-generated from template
 ///</summary>
 public  class signal : NFX.Templatization.Template<object, NFX.Templatization.IRenderingTarget, object>
 {

     protected override void DoRender()
     {
       base.DoRender();
        Target.Write( signal._81_S_LITERAL_0 );

     }


     #region Literal blocks content
        private const string _81_S_LITERAL_0 = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
  <title>Signal</title>
  <style type=""text/css"">
    /*line {shape-rendering: crispEdges; }
    rect {shape-rendering: crispEdges; }*/

    rect.wvSvgBkgr { fill: #f9f6f6; }
    line.wvAxisLine { stroke: #000000; stroke-width: 1; }
    line.wvAxisTickLine { stroke: #000000;}

    line.wvGridLine { stroke: #cccccc; stroke-width: 1; stroke-dasharray: 2,2; }
    /*wvGridXLine { stroke: #000000; stroke-width: 1; }*/

    rect.wvXZoneBackground { fill: #e6e9e9; }
    text.wvAxisLabel { fill: #000000; font-family: verdana, sans-serif; font-size: 10px; }
    /*text.wvXAxisLabel { fill: #000000; font-size: 10px; }*/

    rect.wvYZoneBackground { fill: #e9e6e6; }

    rect.wvSZoneBackground { fill: #ffffff; }

    path.wvSeriesLine { stroke: #ff00ff; fill: none; stroke-width: 2px; }
    path.wvSeriesLineSquare { stroke: #ff00ff; fill: rgba(245, 115, 115, 0.44); }

    path.wvSeriesLine-1 { stroke: #ff0000; fill: none; stroke-width: 1px; }
    path.wvSeriesLineSquare-1 { stroke: #ff0000; fill: rgba(115, 245, 115, 0.44); }

    path.wvSeriesLine-2 { stroke: #0000ff; fill: none; stroke-width: 1px; }
    path.wvSeriesLineSquare-2 { stroke: #0000ff; fill: rgba(25, 61, 235, 0.47) ; }

    path.wvSeriesLine-3 { stroke: #ffff00; fill: none; stroke-width: 1px; }
    path.wvSeriesLineSquare-3 { stroke: #ffff00; fill: rgba(25, 61, 235, 0.47) ; }

    circle.wvSeriesPointCircle { fill: #00aa00; }
    rect.wvSeriesPointRect { fill: #0000aa; }
    path.wvSeriesPointTriangle { fill: #aa0000; }

    rect.wvSeriesRect { fill: #aaaa00; }
    rect.series-rect-1 { fill: #0000aa; }
    rect.series-rect-2 { fill: #00aa00; }

    path.series-line-0 { stroke: #990000; fill: none; }
    path.series-line-1 { stroke: #009900; fill: none; }
    path.series-line-2 { stroke: #000099; fill: none; }
    path.series-line-3 { stroke: #999900; fill: none; }
    path.series-line-4 { stroke: #999999; fill: none; }
    path.series-line-5 { stroke: #119900; fill: none; }
    path.series-line-6 { stroke: #119911; fill: none; }

    svg2 path.series-line-0 { stroke: #ff0000; fill: none; }
    svg2 path.series-line-1 { stroke: #00ff00; fill: none; }
    svg2 path.series-line-2 { stroke: #0000ff; fill: none; }
    svg2 path.series-line-3 { stroke: #ffff00; fill: none; }

    circle.series-point-1 { fill: #0000bb; }

    rect.wvLZoneBackground { fill: #ffffff; stroke: #000000;}
    text.wvLegendName { fill: #000000; font-family: verdana, sans-serif; font-size: 12px; }


    #chart {
      float: left;
      width: 60%;
      background-color: #f0f0f0;
      margin: 0; padding: 0;
      border: none;
    }
    svg {
      border: none;
      margin: 0; padding: 0;
    }
    #lZone {
      width: 200px;
      clear: both;
    }
    input[type=""number""] {
      width: 60px;
      clear: both;
    }
    .field {
      margin: 3px;
    }
    #manage {
      float: right;
      background-color: #eeeeee;
      width: 40%;
    }
      #manage fieldset { display: table; }
      #manage p { display: table-row; }
      #manage label { display: table-cell; width: 80px; }
      #manage input { display: table-cell }

    fieldset.signalDetails {
      width: 75px;
      background-color: #cccccc;
    }

    div.signalDetails {
      float: left;
    }

    div.signalDetails a {
      font-weight: bold;
      cursor: pointer;
      color: #0000ff;
    }

    #dvInstructions {
      color: #585976;
    }

      #dvInstructions span {
        font-weight: bold;
        color: #1d810a;
      }

    .xBound { background-color: #ffff80; }
    .yBound { border: 3px solid #8080ff; }
  </style>
  <script src=""jquery-2.1.4.min.js""></script>
  <script src=""wv.js""></script>
  <script src=""wv.chart.svg.js""></script>
  <script>
    var chart, series0;
    var DEFAULT_SAMPLING_RATE = 1000;
    var DEFAULT_CFG = {
      f: 1.0,
      a: 1,
      d: 0,
      r: 1000,
      p: 0,
      s: .9,
      m: 1,
      k: 0
    };

    var timer;
    var chart;

    $(function(){
      var svgel = $(""#svg1"")[0];
      chart = new WAVE.Chart.SVG.Chart(svgel);
      function pad(n) { return n < 10 ? '0' + n : n }
      
      chart.xAxis().labelValToStr = chart.yAxis().labelValToStr = function(n) { return n.toFixed(3); }
      
      $(document).mousemove(onMouseMove);
      $(document).click(onClick);
      timer = setInterval(function() {
        drawChart();
      }, 1000);
    });

    function drawChart() {
      chart.beginUpdate();
      chart.clearSeries();

      if($(""#chkMarginAuto"").is("":checked"")) {
        chart.yAxis().min(null);
        chart.yAxis().max(null);
      } else {
        chart.yAxis().min(parseFloat($(""#numYMin"").val()));
        chart.yAxis().max(parseFloat($(""#numYMax"").val()));
      }

      var lineStyles = [""wvSeriesLine-1"", ""wvSeriesLine-2"", ""wvSeriesLine-3""];
      var currStyleIdx = 0;
      var individualSrcCodes = [];

      var signalsEl = $(""#signalChain fieldset[signal]"");

      var signalCode = ""WAVE.signalConstSrc()"";
      
      $(""#signalChain fieldset[signal]"").each(function(){

        var signalFS = $(this);

        var signalKind = signalFS.attr(""signal"");

        var cfg = {
          f: parseFloat(signalFS.children(""[property=f]"").eq(0).val()),
          a: parseFloat(signalFS.children(""[property=a]"").eq(0).val()),
          d: parseFloat(signalFS.children(""[property=d]"").eq(0).val()),
          r: parseFloat(signalFS.children(""[property=r]"").eq(0).val()),
          p: parseFloat(signalFS.children(""[property=p]"").eq(0).val()),
          s: parseFloat(signalFS.children(""[property=s]"").eq(0).val())
        };

        var m = parseFloat(signalFS.children(""[property=m]"").eq(0).val());
        var k = parseFloat(signalFS.children(""[property=k]"").eq(0).val());

        var showIndividualChart = signalFS.children(""[property=showIndividualChart]"").is("":checked"");

        for(var i in cfg) if ( isNaN(cfg[i])) delete cfg[i];

        var invividualSignalCode;

        if (signalKind == ""sine"") {
          invividualSignalCode = "".wSineGen("" + JSON.stringify(cfg) + "")"";
        } else if (signalKind == ""saw"") {
          invividualSignalCode = "".wSawGen("" + JSON.stringify(cfg) + "")"";
        } else if (signalKind == ""square"") {
          invividualSignalCode = "".wSquareGen("" + JSON.stringify(cfg) + "")"";
        } else if (signalKind == ""random"") {
          invividualSignalCode = "".wRandomGen("" + JSON.stringify(cfg) + "")"";
        } else if (signalKind == ""wma"") {
          invividualSignalCode = "".wWMA("" + k + "")"";
        } else if (signalKind == ""harmonic"") {
          invividualSignalCode = "".wHarmonicFrequencyFilter("" + m + "", "" + k + "")"";
        } 

        signalCode += invividualSignalCode;

        if (showIndividualChart) {
          
          var individualSignalWalkableSrc;
          var individualSignalWalkableCode = ""individualSignalWalkableSrc = WAVE.signalConstSrc()"" + invividualSignalCode + "";"";
          eval(individualSignalWalkableCode);
          individualSignalWalkableSrc = individualSignalWalkableSrc.wSelect(function(e) { return {x: e.s, y: e.a} });

          individualSrcCodes.push(individualSignalWalkableSrc);
        }
      });

      var signalSrc;
      signalCode =  ""signalSrc = "" + signalCode + "";"";
      eval(signalCode);
      var samplingRate = signalSrc.getWalker().samplingRate();

      signalSrc = signalSrc.wSelect(function(e) { return {x: e.s, y: e.a}; })
        .wTakeWhile(function(e) { return e.x < samplingRate});

      for(var i in individualSrcCodes) {
        if (currStyleIdx >= lineStyles.length) currStyleIdx = 0;
        var series = chart.addSeries({ lineClass: lineStyles[currStyleIdx++]});
        series.dataSet().feedWalkable(individualSrcCodes[i].wTakeWhile(function(e) { return e.x < samplingRate}));
      }

      var series0 = chart.addSeries({ title: ""series 0"" });;

      series0.dataSet().feedWalkable(signalSrc);

      chart.endUpdate();

      audPlay(signalSrc, samplingRate);
    }

    function onSignalChanged(evt) {
      //var el = $(evt.target);
      //if (el.parents(""#signalChain"").length > 0) 
      //  drawChart();
    }

    function allowDrop(ev) { ev.preventDefault(); }

    function onDrag(ev) { ev.dataTransfer.setData(""text/html"", ev.target.id); }


    function onDropIntoChain(ev) {
      ev.preventDefault();

      var insertedId = ev.dataTransfer.getData(""text/html"");
      var insertedEl = $(""#"" + insertedId).eq(0);

      var targetEl = $(ev.target);
      if(targetEl.attr(""id"") == ""signalChain"") {
        targetEl.append(insertedEl);
      } else {
        var divTargetEl = targetEl.parents(""div.signalDetails"").eq(0);
        if (divTargetEl.length > 0) divTargetEl.before(insertedEl);
      }

      drawChart();
    }

    function onDropIntoDepot(ev) {
      ev.preventDefault();

      var insertedId = ev.dataTransfer.getData(""text/html"");
      var insertedEl = $(""#"" + insertedId).eq(0);

      var targetEl = $(ev.target);
      if(targetEl.attr(""id"") == ""signalDepot"") {
        targetEl.append(insertedEl);
      } else {
        var divTargetEl = targetEl.parents(""div.signalDetails"").eq(0);
        if (divTargetEl.length > 0) divTargetEl.before(insertedEl);
      }

      drawChart();
    }

    function onNewSignal(kind) {
      var html;
      switch(kind) {
        case ""saw"":
            html = getSawHtml();
          break;
        case ""square"":
            html = getSquareHtml();
          break;
        case ""random"":
            html = getRandomHtml();
          break;
        case ""wma"":
            html = getWMAHtml();
          break;
        case ""harmonic"":
            html = getHarmonicHtml();
          break;
        default:
            html = getSineHtml();
          break;
      }

      $(""#signalChain"").append(html);
      drawChart();
    }

    function generateId() {
      var key = ""id"";
      return ""id_"" + WAVE.genAutoincKey(key);
    }

    function deleteSignal(id) { 
      var el = $(""#"" + id).eq(0); 
      if (el.parents(""#signalChain"").length > 0) {
        el.remove(); 
        drawChart();
      } else {
        el.remove(); 
      }
    }
  
    function getSineHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""sine"">' +
        '   <legend>Sine <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idFrequency@"">Frequency</label><input type=""number"" id=""@idFrequency@"" property=""f"" min=""1"" max=""2000"" value=""@frequency@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idAmplitude@"">Amplitude</label><input type=""number"" id=""@idAmplitude@"" property=""a"" step=""0.05"" min=""-1000"" max=""1000"" value=""@amplitude@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idDCOffset@"">DC Offset</label><input type=""number"" id=""@idDCOffset@"" property=""d"" step=""0.05"" min=""-1000"" max=""1000"" value=""@dcOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSamplingRate@"">Smpl. Rate</label><input type=""number"" id=""@idSamplingRate@"" property=""r"" min=""2"" max=""44100"" value=""@samplingRate@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idPhaseOffset@"">Ph. offset</label><input type=""number"" id=""@idPhaseOffset@"" property=""p"" step=""0.05"" min=""-20000"" max=""20000"" value=""@phaseOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(), 
        idFrequency: generateId(), 
        idAmplitude: generateId(), 
        idDCOffset: generateId(),
        idSamplingRate: generateId(),
        idPhaseOffset: generateId(),
        idSymmetry: generateId(),
        samplingRate: DEFAULT_SAMPLING_RATE,
        frequency: DEFAULT_CFG.f,
        amplitude: DEFAULT_CFG.a,
        dcOffset: DEFAULT_CFG.d,
        samplingRate: DEFAULT_CFG.r,
        phaseOffset: DEFAULT_CFG.p,
        symmetry: DEFAULT_CFG.s
      });

      return html;
    }

    function getSawHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""saw"">' +
        '   <legend>Saw <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idFrequency@"">Frequency</label><input type=""number"" id=""@idFrequency@"" property=""f"" step=""0.05"" min=""0.1"" max=""20000"" value=""@frequency@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)""  />' +
        '   <label for=""@idAmplitude@"">Amplitude</label><input type=""number"" id=""@idAmplitude@"" property=""a"" step=""0.05"" min=""-1000"" max=""1000"" value=""@amplitude@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idDCOffset@"">DC Offset</label><input type=""number"" id=""@idDCOffset@"" property=""d"" step=""0.05"" min=""-1000"" max=""1000"" value=""@dcOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSamplingRate@"">Smpl. Rate</label><input type=""number"" id=""@idSamplingRate@"" property=""r"" min=""2"" max=""44100"" value=""@samplingRate@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idPhaseOffset@"">Ph. offset</label><input type=""number"" id=""@idPhaseOffset@"" property=""p"" step=""0.05"" min=""-20000"" max=""20000"" value=""@phaseOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSymmetry@"">Symmetry</label><input type=""number"" id=""@idSymmetry@"" property=""s"" step=""0.02"" min=""0.02"" max=""0.98"" value=""@symmetry@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(), 
        idFrequency: generateId(), 
        idAmplitude: generateId(), 
        idDCOffset: generateId(),
        idSamplingRate: generateId(),
        idPhaseOffset: generateId(),
        idSymmetry: generateId(),
        samplingRate: DEFAULT_SAMPLING_RATE,
        frequency: DEFAULT_CFG.f,
        amplitude: DEFAULT_CFG.a,
        dcOffset: DEFAULT_CFG.d,
        samplingRate: DEFAULT_CFG.r,
        phaseOffset: DEFAULT_CFG.p,
        symmetry: DEFAULT_CFG.s
      });

      return html;
    }

    function getSquareHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""square"">' +
        '   <legend>Square <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idFrequency@"">Frequency</label><input type=""number"" id=""@idFrequency@"" property=""f"" step=""0.05"" min=""0.1"" max=""20000"" value=""@frequency@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)""  />' +
        '   <label for=""@idAmplitude@"">Amplitude</label><input type=""number"" id=""@idAmplitude@"" property=""a"" step=""0.05"" min=""-1000"" max=""1000"" value=""@amplitude@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idDCOffset@"">DC Offset</label><input type=""number"" id=""@idDCOffset@"" property=""d"" step=""0.05"" min=""-1000"" max=""1000"" value=""@dcOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSamplingRate@"">Smpl. Rate</label><input type=""number"" id=""@idSamplingRate@"" property=""r"" min=""2"" max=""44100"" value=""@samplingRate@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idPhaseOffset@"">Ph. offset</label><input type=""number"" id=""@idPhaseOffset@"" property=""p"" step=""0.05"" min=""-20000"" max=""20000"" value=""@phaseOffset@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSymmetry@"">Symmetry</label><input type=""number"" id=""@idSymmetry@"" property=""s"" step=""0.02"" min=""0.02"" max=""0.98"" value=""@symmetry@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(), 
        idFrequency: generateId(), 
        idAmplitude: generateId(), 
        idDCOffset: generateId(),
        idSamplingRate: generateId(),
        idPhaseOffset: generateId(),
        idSymmetry: generateId(),
        frequency: DEFAULT_CFG.f,
        amplitude: DEFAULT_CFG.a,
        dcOffset: DEFAULT_CFG.d,
        samplingRate: DEFAULT_CFG.r,
        phaseOffset: DEFAULT_CFG.p,
        symmetry: DEFAULT_CFG.s
      });

      return html;
    }

    function getRandomHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""random"">' +
        '   <legend>Random <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idAmplitude@"">Amplitude</label><input type=""number"" id=""@idAmplitude@"" property=""a"" step=""0.05"" min=""-1000"" max=""1000"" value=""@amplitude@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idSamplingRate@"">Smpl. Rate</label><input type=""number"" id=""@idSamplingRate@"" property=""r"" min=""2"" max=""44100"" value=""@samplingRate@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(), 
        idAmplitude: generateId(), 
        idSamplingRate: generateId(),
        amplitude: DEFAULT_CFG.a,
        samplingRate: DEFAULT_CFG.r
      });

      return html;
    }

    function getWMAHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""wma"">' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <legend>WMA <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idK@"">k (0..1)</label><input type=""number"" id=""@idK@"" property=""k"" step=""0.05"" min=""0"" max=""1"" value=""@k@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(), 
        idK: generateId(), 
        k: DEFAULT_CFG.k
      });

      return html;
    }

    function getHarmonicHtml() {
      var template = 
        '<div id=""@divId@"" class=""signalDetails"" draggable=""true"" ondragstart=""onDrag(event)"">' +
        ' <fieldset class=""signalDetails"" signal=""harmonic"">' +
        '   <legend>Harmonic <a onClick=""deleteSignal(\'@divId@\')"">(-)</a></legend>' +
        '   <label for=""@idShowChart@"">Chart</label><input type=""checkbox"" id=""@idShowChart@"" property=""showIndividualChart"" onchange=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        '   <label for=""@idM@"">m</label><input type=""number"" id=""@idM@"" property=""m"" step=""0.05"" min=""1"" max=""100000"" value=""@m@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)""  onChange=""onSignalChanged(event)""/>' +
        '   <label for=""@idK@"">k</label><input type=""number"" id=""@idK@"" property=""k"" step=""0.05"" min=""0"" max=""100000"" value=""@k@"" onKeyUp=""onSignalChanged(event)"" onInput=""onSignalChanged(event)"" />' +
        ' </fieldset>' +
        '</div>';

      var html = WAVE.strTemplate(template, {
        divId: generateId(), 
        idShowChart: generateId(),
        idM: generateId(), 
        m: DEFAULT_CFG.m,
        idK: generateId(), 
        k: DEFAULT_CFG.k
      });

      return html;
    }


    var audCtx = new (window.AudioContext || window.webkitAudioContext)(); 
    var audSrc = null;

    function audPlay(walkableSignal, samplingRate)
    {
        if (audSrc) { audSrc.stop(); }

        if($(""#chkMute"").is("":checked"")) return;

        var samplingK = audCtx.sampleRate / samplingRate;

        var audFrameCount = audCtx.sampleRate / samplingK;//sec

        var audArrayBuffer = audCtx.createBuffer(1, audFrameCount, audCtx.sampleRate);

        var walker = walkableSignal.getWalker(samplingK);

        var channelBuffer = audArrayBuffer.getChannelData(0);//mono
        
        
        for (var i = 0; i < audFrameCount; i++) {
            if (!walker.moveNext()) break;
            channelBuffer[i] = walker.current().y;// / 100.0;
        }

          audSrc = audCtx.createBufferSource();
          audSrc.loop = true;
          audSrc.buffer = audArrayBuffer;
          audSrc.connect(audCtx.destination);
          audSrc.start();
    }//audPlay(walkableSignal)

    var boundNumericAlt = null, boundNumericShift = null;

    function onClick(evt) {
      var el = $(document.elementFromPoint(evt.pageX, evt.pageY)).eq(0);
      if (el.attr(""type"") != ""number"") return;

      if (evt.shiftKey) {
        if ((boundNumericShift ? boundNumericShift.attr(""id"") : null) == el.attr(""id"")) {
          if (boundNumericShift) {
            boundNumericShift.removeClass(""yBound"");
            boundNumericShift = null;
          }
        } else {
          if (boundNumericShift) boundNumericShift.removeClass(""yBound"");
          boundNumericShift = el;
          boundNumericShift.addClass(""yBound"");
        }
      } else if (evt.altKey) {
        if ((boundNumericAlt ? boundNumericAlt.attr(""id"") : null) == el.attr(""id"")) {
          if (boundNumericAlt) {
            boundNumericAlt.removeClass(""xBound"");
            boundNumericAlt = null;
          }
        } else {
          if (boundNumericAlt) boundNumericAlt.removeClass(""xBound"");
          boundNumericAlt = el;
          boundNumericAlt.addClass(""xBound"");
        }
      }
    }

    function onMouseMove(evt) {

      if (!boundNumericAlt && !boundNumericShift) return;

      var width = $(document).width();
      var height = $(document).height();

      if (boundNumericAlt) {
        var elMin = parseFloat(boundNumericAlt.attr(""min""));
        var elMax = parseFloat(boundNumericAlt.attr(""max""));

        var kx = evt.pageX / width;
        var elVal = (elMax - elMin) * kx + elMin;

        boundNumericAlt.val(elVal);
      }

      if (boundNumericShift) {
        var elMin = parseFloat(boundNumericShift.attr(""min""));
        var elMax = parseFloat(boundNumericShift.attr(""max""));

        var kx = evt.pageX / width;
        var elVal = (elMax - elMin) * kx + elMin;

        boundNumericShift.val(elVal);
      }
    }
   
  </script>
</head>
<body>
  <div id=""dvInstructions"">
    <span>Alt-click</span> on any generator numeric field to bind/unbind its value to <span>X</span> mouse coordinate.<br>
    <span>Shift-click</span> on any generator numeric field to bind/unbind its value to Y <span>mouse</span> coordinate.
  </div>

  <div id=""chart"">
    <svg id=""svg1"" width=""100%"" height=""500"" viewBox=""0 0 1000 500"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">
    </svg>
  </div>

  <div id=""manage"">

    <fieldset>
      <legend>Common</legend>
      <p>
        <label for=""chkMute"" style=""width: 30px"">Mute:</label>
        <input type=""checkbox"" id=""chkMute"" value=""true"" checked onchange=""drawChart()"" >
        <label for=""chkMarginAuto"" style=""width: 90px;"">Auto Margin:</label>
        <input type=""checkbox"" id=""chkMarginAuto"" value=""true"" checked onchange=""drawChart()"" />
        <label for=""numYMin"" style=""width: 55px;"">Y Min:</label>
        <input type=""number"" id=""numYMin"" onkeyup=""drawChart()"" oninput=""drawChart()"" />
        <label for=""numYMax"" style=""width: 55px;"">Y Max:</label>
        <input type=""number"" id=""numYMax"" onabort onkeyup=""drawChart()"" oninput=""drawChart()"" />
      </p>
    </fieldset>

    <fieldset>
      <legend>Signal Patterns</legend>
      <p>
        <button onclick=""onNewSignal('sine')"">New Sine</button>
        <button onclick=""onNewSignal('saw')"">New Saw</button>
        <button onclick=""onNewSignal('square')"">New Square</button>
        <button onclick=""onNewSignal('random')"">New Random</button>
        <button onclick=""onNewSignal('harmonic')"">New Harmonic</button>
        <button onclick=""onNewSignal('wma')"">New WMA</button>
      </p>
    </fieldset>

    <fieldset id=""signalChain"" ondrop=""onDropIntoChain(event)"" ondragover=""allowDrop(event)"">
      <legend>Chain</legend>

    </fieldset>

    <fieldset id=""signalDepot"" ondrop=""onDropIntoDepot(event)"" ondragover=""allowDrop(event)"">
      <legend>Depot</legend>
    </fieldset>

  </div>

</body>
</html>"; 
     #endregion

 }//class
}//namespace
