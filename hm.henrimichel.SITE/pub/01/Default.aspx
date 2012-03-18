<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="hm.henrimichel.SITE._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Henri Michel</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/jScrollPane.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script src="js/jquery.mousewheel.js" type="text/javascript"></script>
    <script src="js/jScrollPane.js" type="text/javascript"></script>

	<script type="text/javascript" src="js/mootools-1.2-core.js"></script>
	<script type="text/javascript" src="js/_class.noobSlide.packed.js"></script>

    <script src="js/cufon-yui.js" type="text/javascript"></script>
    <script src="js/Bring_tha_noize_400.font.js" type="text/javascript"></script>
	<script type="text/javascript">

			Cufon.replace('h1'); // Works without a selector engine

			

	window.addEvent('domready',function(){
	    
       
		
        //SAMPLE 4 (walk to item)
		var nS4 = new noobSlide({
			box: $('box4'),
			items: $$('#box4 div'),
			size: 346,
			handles: $$('#ulSlide li'),
			onWalk: function(currentItem,currentHandle){
				
				this.handles.removeClass('active');
				currentHandle.addClass('active');
			}
		});

		

});

		

	</script>
    <script type="text/javascript">

    jQuery(
	function()
	{
	    jQuery('.tweetlist').jScrollPane({ showArrows: false, scrollbarWidth: 5 });
	}
);
		

	</script>


</head>
<body>

    
    <form id="form1" runat="server">
<center>
        <div class="pagina">
            <div class="dv1 header ClearBoth">
                <img src="img/logotopo.png" />
            </div> 
              
            <div class="dv1 centro ClearBoth">
                <img src="img/central01.png" />
            </div>

            <div class="dv1 conteudo ClearBoth">
                <div class="dv1-3">
                    <h1>Twitter @henricavalcante</h1>
                    <asp:Repeater ID="repTwitterFromMe" runat="server">
                        <HeaderTemplate>
                        <div id="TwitterFromMe" class="tweetlist scroll-pane">
                            <ul>
                        </HeaderTemplate>
                
                        <ItemTemplate>
                            <li>
                                <div class="tweetdate">
                                    <div class="lbl2bold">
                                        <%# Format(CDate(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("pubDate").InnerText), "hh:mm")%>
                                    </div>
                                    <div class="lbl2bold">
                                        <%# Format(CDate(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("pubDate").InnerText), "dd/MM")%>
                                    </div>
                                </div>
                                <div class="tweet lbl">
                                    <a href='<%#DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("link").InnerText%>'>
                                        <%#GetTweets(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("description").InnerText)%>
                                    </a>
                                </div>
                                
                            </li>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repTwitterToMe" runat="server">
                        <HeaderTemplate>
                        <div id="TwitterToMe" class="tweetlist scroll-pane">
                            <ul>
                        </HeaderTemplate>
                
                        <ItemTemplate>
                            <li>
                                <div class="tweetdate">
                                    <div class="lbl2bold">
                                        <%# Format(CDate(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("pubDate").InnerText), "hh:mm")%>
                                    </div>
                                    <div class="lbl2bold">
                                        <%# Format(CDate(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("pubDate").InnerText), "dd/MM")%>
                                    </div>
                                </div>
                                <div class="tweet lbl">
                                <a href='<%# String.Format("http://www.twitter.com/{0}",GetAutor(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("author").InnerText))%>'>
                                        <b>
                                            <%# GetAutor(DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("author").InnerText)%>
                                        </b>
                                    </a>
                                    <a href='<%#DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("link").InnerText%>'>
                                        <%# DirectCast(Container.DataItem, System.Xml.XmlNode).SelectSingleNode("description").InnerText%>
                                    </a>
                                </div>
                                
                            </li>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </div>
                        </FooterTemplate>
                    </asp:Repeater>                    
                    
                </div>
            
                <div class="dv2-3">
                    <h1>Trabalhos</h1>
		            <div class="computer_screen">
                        <div class="computer_screen_aux">
                    
                            <div id="box4" class="computer_screen_interno">

                                
	                            <div>
                                    <center>
                                    <object id="twitcamPlayer" width="320" height="265" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000">
                                        <param name="movie" value='<%= String.format("http://static.livestream.com/chromelessPlayer/wrappers/TwitcamPlayer.swf?hash={0}",TwitCamHash) %>'/>
                                        <param name="allowScriptAccess" value="always"/>
                                        <param name="allowFullScreen" value="true"/>
                                        <param name="wmode" value="window"/>
                                        <embed name="twitcamPlayer" src='<%= String.Format("http://static.livestream.com/chromelessPlayer/wrappers/TwitcamPlayer.swf?hash={0}",TwitCamHash) %>' allowFullScreen="true" allowScriptAccess="always" type="application/x-shockwave-flash" bgcolor="#ffffff" width="320" height="265" wmode="window" >
                                        </embed></object>
                                    </center>
		                            
	                            </div>
                			
                                
	                            <div>
		                            <a href="http://www.muambba.com.br/">
                                        <img src="img/slider_images/img1.jpg" alt="Muambba"/>
                                    </a>
	                            </div>

	                            <div>
                                    <a href="http://www.tacomtudo.com.br/">
                                        <img src="img/slider_images/img2.jpg" alt="Tá com tudo"/>
                                    </a>
	                            </div>

                            </div>
                        <ul id="ulSlide">
                            <li><img src="img/slider_btn.png"/></li>
                            <li><img src="img/slider_btn.png"/></li>
                            <li><img src="img/slider_btn.png"/></li>
                            
                		
                        </ul>
                        </div>		        
		            

                 
		            </div>
		        </div>

		        
                  
	        </div> 
        </div>
       
    <div class="footer dv1 ClearBoth">
        <div>
            <img src="img/logofooter.png" />
            
                <span class="lbl bold center">contato@henrimichel.com.br</span>
            
        </div>

    </div>
</center> 
    
    </form>
</body>
</html>
