console.clear();

//#region Imports
const fs = require('fs');
//#endregion

//#region Load the source file
const source = fs.readFileSync('source.xaml');
//console.log(source.toString());
//#endregion

//#region Get x:Key Color properties on the source XAML
let typeCounts = {};
let baseKeys = [];

let keys = [];
let match;
const regex = /^.*x:Key="(.*?)" Color="(.*?)".*$/gm;
while ((match = regex.exec(source)) !== null)
{
    // This is necessary to avoid infinite loops with zero-width matches
    if (match.index === regex.lastIndex) regex.lastIndex++;

    if (!match[1].includes(".")) continue; //All properties we want include a dot.

    const matchData =
    {
        line: match[0],
        key: match[1].split("."),
        value: match[2]
    };

    if (typeCounts[matchData.key[0]] == null) typeCounts[matchData.key[0]] = 0;
    typeCounts[matchData.key[0]]++;

    //Skip all base properties.
    if (matchData.key[1] === "Static"
        && ["Foreground", "Background", "Border"].includes(matchData.key[2]))
    {
        baseKeys.push(matchData);
        continue;
    }

    if (!keys.includes(matchData)) keys.push(matchData);
}

let manualKeys = [];
const manualRegex = /^.*x:Key="(.*?)".*$/gm;
while ((match = manualRegex.exec(source)) !== null)
{
    if (match.index === manualRegex.lastIndex) manualRegex.lastIndex++;

    if (!match[1].includes(".")) continue;

    const matchData =
    {
        line: match[0],
        key: match[1].split("."),
        value: "null",
        manual: true
    };

    //Make sure the line dosen't exist in the other lists.
    if (keys.find(x => x.line === matchData.line)
        || baseKeys.find(x => x.line === matchData.line)) continue;

    if (typeCounts[matchData.key[0]] == null) typeCounts[matchData.key[0]] = 0;
    typeCounts[matchData.key[0]]++;

    //Skip all base properties.
    if (matchData.key[1] === "Static"
        && ["Foreground", "Background", "Border"].includes(matchData.key[2]))
    {
        baseKeys.push(matchData);
        continue;
    }

    if (!manualKeys.includes(matchData)) manualKeys.push(matchData);
}
const dominantType = Object.keys(typeCounts).sort((a, b) => typeCounts[b] - typeCounts[a])[0];

// console.log(keys);
// console.log(manualKeys);
// console.log(baseKeys);
//#endregion

//#region Build CS File
let modifiedCS = `using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class ${dominantType} : System.Windows.Controls.${dominantType}
    {
`;
keys.concat(manualKeys/*, baseKeys*/).forEach(x =>
{
    const type = x.key[0];

    let propertyName = x.key.slice(1, x.key.length).join("");
    if (propertyName.endsWith("Border")) propertyName += "Brush";

    const defaultValue = x.manual ? "null /*MANUAL*/" : `"${x.value}".ToBrush()`;

    const line1 = `public static readonly DependencyProperty ${propertyName}Property = DependencyExt.RegisterDependencyProperty<${type}, Brush>(nameof(${propertyName}), ${defaultValue});`;
    const line2 = `public Brush ${propertyName} { get => (Brush)GetValue(${propertyName}Property); set => SetValue(${propertyName}Property, value); }`;
    modifiedCS += "\t\t" + line1 + "\n\t\t" + line2 + "\n\n";
});
modifiedCS += `\t\tpublic static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<${dominantType}>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(${dominantType}));

        protected bool styleHasChanged = false;

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!styleHasChanged) Style = BASE_STYLE;
        }

        protected override void OnStyleChanged(Style? oldStyle, Style? newStyle)
        {
            styleHasChanged = true;
            base.OnStyleChanged(oldStyle, newStyle);
        }

        static ${dominantType}() => BASE_STYLE.Seal();

        public ${dominantType}() => Loaded += OnLoaded;
    }
}\n`;
//console.log(modifiedCS);
fs.writeFileSync('modified.xaml.cs', modifiedCS);
//#endregion

//#region Build the modified XAML
let modifiedXaml = source.toString();
keys.concat(baseKeys).forEach(x =>
{
    //#region Replace StaticResouce bindings
    const type = x.key[0];

    const oldPropertyName = x.key.join(".");
    let newPropertyName = x.key.slice(1, x.key.length).join("");
    if (newPropertyName.endsWith("Border")) newPropertyName += "Brush";

    const find = `{StaticResource ${oldPropertyName}}`;
    const replace = `{Binding RelativeSource={RelativeSource AncestorType={x:Type local:${type}}}, Path=${newPropertyName}}`;
    //console.log(find, replace);

    modifiedXaml = modifiedXaml.replaceAll(find, replace);
    //#endregion

    //#region Remove the old resource line
    // modifiedXaml = modifiedXaml.replaceAll(x.line + "\n", "");
    modifiedXaml = modifiedXaml.replaceAll(x.line, "");
    //#endregion
});

manualKeys.forEach(x =>
{
    //#region Replace StaticResouce bindings
    const type = x.key[0];

    const oldPropertyName = x.key.join(".");
    let newPropertyName = x.key.slice(2, x.key.length).join("");
    if (newPropertyName.endsWith("Border")) newPropertyName += "Brush";

    const find = `{StaticResource ${oldPropertyName}}`;
    const replace = `{Binding RelativeSource={RelativeSource AncestorType={x:Type local:${type}}} Path=${newPropertyName}}`;
    //console.log(find, replace);

    modifiedXaml = modifiedXaml.replaceAll(find, replace);
    //#endregion

    //#region Mark the old lines for manual modifications
    modifiedXaml = modifiedXaml.replaceAll(x.line, `<!--MANUAL-->${x.line}`);
    //#endregion
});

//#region Remove empty lines
//https://stackoverflow.com/questions/16369642/javascript-how-to-use-a-regular-expression-to-remove-blank-lines-from-a-string
modifiedXaml = modifiedXaml.replace(/^\s*$(?:\r\n?|\n)/gm, "");
//#endregion

//console.log(modifiedXaml);
fs.writeFileSync('modified.xaml', modifiedXaml);
//#endregion
