




using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable]
public class OuterObject 
{
    public int OuterVariable;

    [XmlElementAttribute("test")]
    public Collection<MyObject> MyObjects { get; set; }
}


[Serializable]
public class MyObject : IXmlSerializable
{
    public int n1;
    public int n2;
    public String str;

    public MyObject()
    {
    }

    protected MyObject(SerializationInfo info, StreamingContext context)
    {
        n1 = info.GetInt32("i");

    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        
        info.AddValue("i", n1);

    }

    public XmlSchema? GetSchema()
    {
        return (null);
    }

    public void ReadXml(XmlReader reader)
    {
        //reader.MoveToContent();

        var val = reader.ReadElementContentAsString("test", "");

        XDocument doc = XDocument.Parse(val);
        var n1FromXml = doc.Root.Element("n1").Value;
        var n2FromXml = doc.Root.Element("n2").Value;

        n1 = int.Parse(n1FromXml);
        n2 = int.Parse(n2FromXml);

        //reader.Skip();
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteString($"<MyObject><n1>500188{DateTime.Now.Second}</n1><n2>500777{DateTime.Now.Second}</n2></MyObject>");
    }
}