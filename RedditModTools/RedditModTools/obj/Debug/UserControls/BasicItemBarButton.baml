   M S B A M L   `   `   `  ����I  ERedditModTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RedditModTools.UserControlsRedditModTools.UserControls  5      4    .RedditModTools.UserControls.BasicItemBarButton   5   $   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      BuserControls)clr-namespace:RedditModTools.UserControls     5      6   0RedditModTools.UserControls.UserControlWithClick    
MouseEnter$  UserControl_MouseEnter��5   /      	MouseDown$ UserControl_MouseDown��6S      
MouseLeave$ UserControl_MouseLeave��6u      MouseUp$ UserControl_MouseUp��6�   $	��100��6   .��5	      � -   5         �Name$ mainGrid��5	      ��5
   
   �� 5      -   5        bgBrush�� �� ImageSource$ Images/barTriple.png��5   +    j� Stretch$
 None=�6N    j� 
AlignmentX$
 Left=�6]    j� 
AlignmentY$	 Top=�6o   	 �� RelativeTransform	 5      V� 5      .~�5      �� 
 �� CenterY$	
 0.5Q�6)    �� CenterX$	 0.5Q�67   �� 5       �� CenterY$	 0.5Q�6(    �� CenterX$	 0.5Q�66   �� 5       �� CenterY$	 0.5Q�6*    �� CenterX$	 0.5Q�68   T� 5      5      5      .+�5   
   �� -   5         ��Name$ buttonLabel��5      $��Label��6%   $��Center=�65   $��0q�6R   $��Center=�6]   $��22(�6x   $
��Bold"�6�   .   (RedditModTools.UserControls.LittleToggle  5   
   -   5          Name$ toggleRule1��5   $   $��10,10,70,80q�69   $y�	Collapsed=�6N      idValue$ 1��6e     5   
   -   5        $ toggleRule2��5   $   $��40,10,40,80q�69   $y�	Collapsed=�6N   $ 2��6e     5   
   -   5        $ toggleRule3��5   $   $��70,10,10,80q�69   $y�	Collapsed=�6N   $ 3��6e     5   
   -   5        $ toggleRule4��5   $   $��10,80,70,10q�69   $y�	Collapsed=�6N   $ 4��6e     5   
   -   5        $ toggleRule5��5   $   $��30,80,50,10q�69   $y�	Collapsed=�6N   $ 5��6e     5   
   -	   5        $ toggleRule6��5   $   $��50,80,30,10q�69   $y�	Collapsed=�6N   $ 6��6e     5   
   -
   5        $ toggleRule7��5   $   $��70,80,10,10q�69   $y�	Collapsed=�6N   $ 7��6e   3   -RedditModTools.UserControls.ForwardBackButton  5    
   -   5          Name$ 
backButton��5    )      isBackButton . $��10,30,50,30q�6Q   $y�	Collapsed=�6f     5!   
   -   5        $ forwardButton��5!   )    .  $��50,30,10,30q�6U   $y�	Collapsed=�6j   5"      5#      