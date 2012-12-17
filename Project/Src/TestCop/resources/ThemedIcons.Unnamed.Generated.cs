//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Windows.Markup.XmlnsDefinitionAttribute("urn:shemas-jetbrains-com:ui-application-icons-unnamed", "TestCop")]
[assembly: global::JetBrains.UI.Icons.CompiledIcons.CompiledIconsPackAttribute(IconPackResourceIdentification="TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", IconNames=new string[] {
		"Agent16x16",
		"Agent64x64",
		"Agent48x48"})]

namespace TestCop
{
	
	
	/// <summary>
	///  <para>
	///    <para>Autogenerated identifier classes and identifier objects to Themed Icons registered with <see cref="JetBrains.UI.Icons.IThemedIconManager" />.</para>
	///    <para>Identifier classes should be used in attributes, XAML, or generic parameters. Where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected, use the identifier object in the <c>Id</c> field of the identifier class.</para>
	///  </para>
	///</summary>
	///<remarks>
	///  <para>This code was compile-time generated to support Themed Icons in the JetBrains application.</para>
	///  <para>It has two primary goals: load the icons of this assembly to be registered with <see cref="JetBrains.UI.Icons.IThemedIconManager" /> so that they were WPF-accessible and theme-sensitive; and emit early-bound accessors for referencing icons in codebehind in a compile-time-validated manner.</para>
	///  <h1>XAML</h1>
	///  <para>For performance reasons, the icons are not individually exposed with application resources. There is a custom markup extension to bind an image source in markup.</para>
	///  <para>To use an icon from XAML, set an <see cref="System.Windows.Media.ImageSource" /> property to the <see cref="JetBrains.UI.Icons.ThemedIconExtension" /> markup extension, which takes an icon identifier class (nested in <see cref="TestCop.UnnamedThemedIcons" /> class) as a parameter.</para>
	///  <para>Example:</para>
	///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent16x16}" /&gt;</code>
	///  <h1>Attributes</h1>
	///  <para>Sometimes you have to reference an icon from a type attriute when you're defining objects in code. Typical examples are Options pages and Tool Windows.</para>
	///  <para>To avoid the use of string IDs which are not validated very well, we've emitted identifier classes to be used with <c>typeof()</c> expression, one per each icon. Use the attribute overload which takes a <see cref="System.Type" /> for an image, and choose your icon class from nested classes in the <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
	///  <para>Example:</para>
	///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent16x16))]</code>
	///  <h1>CodeBehind</h1>
	///  <para>In codebehind, we have two distinct tasks: (a) specify some icon in the APIs and (b) render icon images onscreen.</para>
	///  <para>On the APIs stage you should only manipulate icon identifier objects (of type <see cref="JetBrains.UI.Icons.IconId" />, statically defined in <see cref="TestCop.UnnamedThemedIcons" /> in <c>Id</c> fields). Icon identifier classes (nested in <see cref="TestCop.UnnamedThemedIcons" />) should be turned into icon identifier objects as early as possible. Rendering is about getting an <see cref="System.Windows.Media.ImageSource" /> to assign to WPF, or <see cref="System.Drawing.Bitmap" /> to use with GDI+ / Windows Forms.</para>
	///  <para>You should turn an identifier object into a rendered image as late as possible. The identifier is static and lightweight and does not depend on the current theme, while the image is themed and has to be loaded or generated/rasterized. You need an <see cref="JetBrains.UI.Icons.IThemedIconManager" /> instance to get the image out of an icon identifier object. Once you got the image, you should take care to change it with theme changes — either by using a live image property, or by listening to the theme change event. See <see cref="JetBrains.UI.Icons.IThemedIconManager" /> and its extensions for the related facilities.</para>
	///  <para>Example:</para>
	///  <code>// Getting IconId identifier object to use with APIs
	///IconId iconid = UnnamedThemedIcons.Agent16x16.Id;</code>
	///  <code>// Getting IconId out of an Icon Identifier Class type
	///IconId iconid = CompiledIconClassAttribute.TryGetCompiledIconClassId(typeof(UnnamedThemedIcons.Agent16x16), OnError.Throw);</code>
	///  <code>// Getting image for screen rendering by IconId
	///themediconmanager.Icons[icnoid]</code>
	///  <code>// Getting image for screen rendering by Icon Identifier Class
	///themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent16x16&gt;()</code>
	///  <h1>Icons Origin</h1>
	///  <para>This code was generated by a pre-compile build task from a set of input files which are XAML files adhering to a certain convention, as convenient for exporting them from the Illustrator workspace, plus separate PNG files with raster icons. In the projects, these files are designated with <c>ThemedIconsXamlV3</c> and <c>ThemedIconPng</c> build actions and do not themselves get into the output assembly. All of such files are processed, vector images for different themes of the same icon are split and combined into the single list of icons in this assembly. This list is then written into the genearted XAML file (compiled into BAML within assembly), and serves as the source for this generated code.</para>
	///</remarks>
	public sealed class UnnamedThemedIcons
	{
		
		/// <summary>
		///  <para>
		///    <para>Autogenerated identifier class for the Agent16x16 Themed Icon.</para>
		///    <para>Identifier classes should be used in attributes, XAML, or generic parameters. Where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected, use the identifier object in the <see cref="TestCop.UnnamedThemedIcons.Agent16x16.Id" /> field of the identifier class.</para>
		///  </para>
		///</summary>
		///<remarks>
		///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
		///</remarks>
		///<seealso cref="TestCop.UnnamedThemedIcons" />
		///<example>
		///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent16x16}" /&gt;        &lt;!-- XAML --&gt;</code>
		///</example>
		///<example>
		///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent16x16))]        // C# Type attribute</code>
		///</example>
		///<example>
		///  <code>IconId iconid = UnnamedThemedIcons.Agent16x16.Id;        // IconId identifier object</code>
		///</example>
		///<example>
		///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent16x16&gt;()        // Icon image for rendering</code>
		///</example>
		[global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClassAttribute("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 0, "Agent16x16")]
		public sealed class Agent16x16 : global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClass
		{
			
			/// <summary>
			///  <para>
			///    <para>Autogenerated identifier object for the Agent16x16 Themed Icon.</para>
			///    <para>Identifier objects should be used where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected. In attributes, XAML, or generic parameters use the containing <see cref="TestCop.UnnamedThemedIcons.Agent16x16" /> identifier class.</para>
			///  </para>
			///</summary>
			///<remarks>
			///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
			///</remarks>
			///<seealso cref="TestCop.UnnamedThemedIcons" />
			///<example>
			///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent16x16}" /&gt;        &lt;!-- XAML --&gt;</code>
			///</example>
			///<example>
			///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent16x16))]        // C# Type attribute</code>
			///</example>
			///<example>
			///  <code>IconId iconid = UnnamedThemedIcons.Agent16x16.Id;        // IconId identifier object</code>
			///</example>
			///<example>
			///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent16x16&gt;()        // Icon image for rendering</code>
			///</example>
			public static global::JetBrains.UI.Icons.IconId Id = new global::JetBrains.UI.Icons.CompiledIcons.CompiledIconId("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 0, "Agent16x16");
		}
		
		/// <summary>
		///  <para>
		///    <para>Autogenerated identifier class for the Agent48x48 Themed Icon.</para>
		///    <para>Identifier classes should be used in attributes, XAML, or generic parameters. Where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected, use the identifier object in the <see cref="TestCop.UnnamedThemedIcons.Agent48x48.Id" /> field of the identifier class.</para>
		///  </para>
		///</summary>
		///<remarks>
		///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
		///</remarks>
		///<seealso cref="TestCop.UnnamedThemedIcons" />
		///<example>
		///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent48x48}" /&gt;        &lt;!-- XAML --&gt;</code>
		///</example>
		///<example>
		///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent48x48))]        // C# Type attribute</code>
		///</example>
		///<example>
		///  <code>IconId iconid = UnnamedThemedIcons.Agent48x48.Id;        // IconId identifier object</code>
		///</example>
		///<example>
		///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent48x48&gt;()        // Icon image for rendering</code>
		///</example>
		[global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClassAttribute("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 2, "Agent48x48")]
		public sealed class Agent48x48 : global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClass
		{
			
			/// <summary>
			///  <para>
			///    <para>Autogenerated identifier object for the Agent48x48 Themed Icon.</para>
			///    <para>Identifier objects should be used where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected. In attributes, XAML, or generic parameters use the containing <see cref="TestCop.UnnamedThemedIcons.Agent48x48" /> identifier class.</para>
			///  </para>
			///</summary>
			///<remarks>
			///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
			///</remarks>
			///<seealso cref="TestCop.UnnamedThemedIcons" />
			///<example>
			///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent48x48}" /&gt;        &lt;!-- XAML --&gt;</code>
			///</example>
			///<example>
			///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent48x48))]        // C# Type attribute</code>
			///</example>
			///<example>
			///  <code>IconId iconid = UnnamedThemedIcons.Agent48x48.Id;        // IconId identifier object</code>
			///</example>
			///<example>
			///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent48x48&gt;()        // Icon image for rendering</code>
			///</example>
			public static global::JetBrains.UI.Icons.IconId Id = new global::JetBrains.UI.Icons.CompiledIcons.CompiledIconId("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 2, "Agent48x48");
		}
		
		/// <summary>
		///  <para>
		///    <para>Autogenerated identifier class for the Agent64x64 Themed Icon.</para>
		///    <para>Identifier classes should be used in attributes, XAML, or generic parameters. Where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected, use the identifier object in the <see cref="TestCop.UnnamedThemedIcons.Agent64x64.Id" /> field of the identifier class.</para>
		///  </para>
		///</summary>
		///<remarks>
		///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
		///</remarks>
		///<seealso cref="TestCop.UnnamedThemedIcons" />
		///<example>
		///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent64x64}" /&gt;        &lt;!-- XAML --&gt;</code>
		///</example>
		///<example>
		///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent64x64))]        // C# Type attribute</code>
		///</example>
		///<example>
		///  <code>IconId iconid = UnnamedThemedIcons.Agent64x64.Id;        // IconId identifier object</code>
		///</example>
		///<example>
		///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent64x64&gt;()        // Icon image for rendering</code>
		///</example>
		[global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClassAttribute("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 1, "Agent64x64")]
		public sealed class Agent64x64 : global::JetBrains.UI.Icons.CompiledIcons.CompiledIconClass
		{
			
			/// <summary>
			///  <para>
			///    <para>Autogenerated identifier object for the Agent64x64 Themed Icon.</para>
			///    <para>Identifier objects should be used where an <see cref="JetBrains.UI.Icons.IconId" /> value is expected. In attributes, XAML, or generic parameters use the containing <see cref="TestCop.UnnamedThemedIcons.Agent64x64" /> identifier class.</para>
			///  </para>
			///</summary>
			///<remarks>
			///  <para>For details on Themed Icons and their use, see Remarks on <see cref="TestCop.UnnamedThemedIcons" /> class.</para>
			///</remarks>
			///<seealso cref="TestCop.UnnamedThemedIcons" />
			///<example>
			///  <code>&lt;Image Source="{icons:ThemedIcon myres:UnnamedThemedIcons+Agent64x64}" /&gt;        &lt;!-- XAML --&gt;</code>
			///</example>
			///<example>
			///  <code>[Item(Name="Sample", Icon=typeof(UnnamedThemedIcons.Agent64x64))]        // C# Type attribute</code>
			///</example>
			///<example>
			///  <code>IconId iconid = UnnamedThemedIcons.Agent64x64.Id;        // IconId identifier object</code>
			///</example>
			///<example>
			///  <code>themediconmanager.GetIcon&lt;UnnamedThemedIcons.Agent64x64&gt;()        // Icon image for rendering</code>
			///</example>
			public static global::JetBrains.UI.Icons.IconId Id = new global::JetBrains.UI.Icons.CompiledIcons.CompiledIconId("TestCopForResharper;component/resources/ThemedIcons.Unnamed.Generated.Xaml", 1, "Agent64x64");
		}
	}
}
