   M S B A M L   `   `   `  ����I  ERedditModTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RedditModTools.UserControlsRedditModTools.UserControls  5   	       RedditModTools.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   BuserControls)clr-namespace:RedditModTools.UserControls     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1218��6)   
���   �.��5      � ���	#FF2A2A2A.+�5   
   +   %RedditModTools.UserControls.TabButton  -   5          Name$ moderatedTabButton��5   !   +   %RedditModTools.UserControls.TabButton   Click$ TabButton_Click��6�      
buttonType$ 	MODERATED=�6=   $
��Left=�6T   $	��Top=�6o   6�     5   
   -   5        $ unmoderatedTabButton��5   !   $ TabButton_Click��6�   $ UNMODERATED=�6?   $
��Left=�6X   $	��Top=�6s   $��70,0,0,0q�6�   6�     5	   
   -   5        $ loginTabButton��5	   !   $ TabButton_Click��6�   $ LOGIN=�69   $��Right=�6L   $	��Top=�6h   6�   � 5   
   -   5         �Name$ moderatedGrid��5      ���	#FFE5E5E5$	��Top=�6=   $��0,70,0,0q�6U   .+�5      )   #RedditModTools.UserControls.ItemBar  -   5          Name$	 bar��5   #   $
��Left=�60   �� 5      -   5         ��Name$
 full��5      $��Button��6#   $
��Left=�64   $��
67,241,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 5      -   5        $ focused��5      $��Button��6&   $
��Left=�67   $��297,250,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5      -   5        $ unfoc��5      $��Button��6$   $
��Left=�65   $��505,250,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      � 5   
   -	   5        $ unmoderatedGrid��5      ���	#FFE5E5E5$	��Top=�6?   $��0,70,0,0q�6W   .+�5      �� -
   5        $ 	popButton��5      $��Button��6(   $
��Left=�69   $��1115,10,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5      $
��Left=�6   $	��496��66   $��0,38,0,0q�6C   $	��Top=�6U   $
��1200��6m   .��5      �� -   5         ��Name$ unModeratedStack��5      $
��1200��67   5      0   *RedditModTools.UserControls.ContentControl  5      -   5          Name$ unmoderatedContentControl��5   *   $��	0,138,0,0q�6M   $y�Hidden=�6`   5      � 5   
   -   5        $ 	loginGrid��5      ���	#FFE5E5E5$	��Top=�69   $��0,70,0,0q�6Q   .+�5      �� -   5        	 ��Name$	 login_usernameTextbox��5      $
��Left=�65   $��23��6P   $��
172,87,0,0q�6\   
 �� TextWrapping$

 Wrap=�6p   $��TextBox��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5        $	 login_passwordTextbox��5      $
��Left=�65   $��23��6P   $��172,133,0,0q�6\   $

 Wrap=�6q   $��TextBox��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ login_loginButton��5      $��Button��60   $
��Left=�6A   $��193,189,0,0q�6\   $	��Top=�6q   $��75��6�   6�   5      5!      5"      