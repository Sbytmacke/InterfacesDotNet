   M S B A M L   `   `   `  ����[  WP05_01_DI_Contactos_MAROTO_angel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Views&P05_01_DI_Contactos_MAROTO_angel.Views  5      i9clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Properties+P05_01_DI_Contactos_MAROTO_angel.Properties  5      i9clr-namespace:P05_01_DI_Contactos_MAROTO_angel.ViewModels+P05_01_DI_Contactos_MAROTO_angel.ViewModels  5      u?clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Utils.Converters1P05_01_DI_Contactos_MAROTO_angel.Utils.Converters  5	      9    3P05_01_DI_Contactos_MAROTO_angel.Views.EmployeeView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Views     5      Gp9clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Properties     5      Hvm9clr-namespace:P05_01_DI_Contactos_MAROTO_angel.ViewModels     5      U	converter?clr-namespace:P05_01_DI_Contactos_MAROTO_angel.Utils.Converters     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      .��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� 
������� �� CornerRadius$ 20��6#   $��5,5,5,5q�65   ._�5      �� -   5         ��Name$ listEmployees��5      $��0��5      ��5      �� *	Employees+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ MouseLeftButtonUp��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SelectEmployeeCommand+   CommandParameter 5   0   �� *SelectedItem+ �� ElementName$ listEmployees��5      	 �� View	 5"      �� 5#      .P�5$      �� 
 �� CellTemplate
 5%      �� 5&   "   .R�5'   &   �� 
���  ����6>   �� *#!DataContext.DeleteEmployeeCommand+ �� RelativeSource ��  �� AncestorType" ����5)   )   �� *Dni+.��5*   *   ��  �� Orientation$ 
Horizontal=�65   .+�5+   .   (� $��20��66   $��20��6A   .��5,   2   F� 
���   ������ � �q� � ޷W `�,����O@� H� H�Q �%&,����O@� �( ޷� H� H�� �( �q� (P7 �q� (P7 @B� H� H�� ظ @B� ظ �q� H� H�� � �q� �� �q� X=$ �q� X=$  �� ��  �� �� �q� �q p89� h�	 (P7� H� H�� h�	 @B� �3 @B� �3 (P7� P�1 p89� H� H�� �q p89� �� ��-� � x�+  H� H�� � ��� `� ��  H� H�� `� x�+� �� ��-  H� H�� X=$ ��-� �%& x�+  H� H�� �%& ��� U" ��  H� H�� U" x�+� X=$ ��-  H� H�	5-   1   5.   /   5/   +   50   '   51   #   53      �� 54      ;   5P05_01_DI_Contactos_MAROTO_angel.Properties.Resources   Name#��Z 6)    �� DisplayMemberBinding 6N   �� *Name+�� 55         Position#��Z 6)    6R   �� *
Position+�� 56         
Department#��Z 6)    6T   �� *DepartmentName+�� 57         Email#��Z 6)    6O   �� *Email+�� 58      
   DNI#��Z 6)    6M   �� *Dni+�� 59         Phone#��Z 6)    6O   �� *Phone+5:      5<      5=      �� 5@   
   $��1��6   $��	80,0,80,0q�6%   .+�5B      �� $��1q�6<   
������ $	��200��6i   $	��200��6u   ��6   �� *SelectImageCommand+.��5C      �� $	��200��6   $	��200��6$   ��5D      �� 5E       �� Path$ Image�6"    �� 	Converter 5F      Q   KP05_01_DI_Contactos_MAROTO_angel.Utils.Converters.ByteArrayToImageConverter  5G   "   5I      5K      5L      �� 5N         TextNameEmployee#��Z 6   �� 5O      
�������$ 10��6(   $��2q�6:   
���   �._�5P      �� $��5q�60   $��0q�6;   
������ ��6   �� *Name+6O   5Q      �� 5S         TextPositionEmployee#��Z 6   �� 5T      
�������$ 10��6(   $��2q�6:   
���   �._�5U      �� $��5q�64   $��0q�6?   
������ ��6   �� *
Position+6S   5V      �� 5X         TextDepartmentEmployee#��Z 6   �� 5Y      
�������$ 10��6(   $��2q�6:   
���   �._�5Z      �� $��5q�6:   $��0q�6E   
������ ��6   �� *DepartmentName+6Y   5[      �� 5]         TextEmailEmployee#��Z 6   �� 5^      
�������$ 10��6(   $��2q�6:   
���   �._�5_      �� $��5q�61   $��0q�6<   
������ ��6   �� *Email+6P   5`      �� 5b         TextDniEmployee#��Z 6   �� 5c      
�������$ 10��6(   $��2q�6:   
���   �._�5d      �� $��5q�6/   $��0q�6:   
������ ��6   �� *Dni+6N   5e      �� 5g         TextPhoneEmployee#��Z 6   �� 5h      
�������$ 10��6(   $��2q�6:   
���   �._�5i      �� $��5q�61   $��0q�6<   
������ ��6   �� *Phone+6P   5j      � 5m      $��0,20,0,0q�6     5n      �� 5o      $��* �6'   �� 5p      $��* �6'   .+�5r      �� $��0��6   
���� ��$ 10��6=   $��2q�6O   
���   �$��	0,10,10,0q�6w    �� Padding$ 10q�6�   ._�5s      �� 
�������   	CreateNew#��Z 61   $��0q�6�   
������ ��6\   �� *CreateEmployeeCommand+6�   5t      �� 5v      $��1��6   
���� ��$ 10��6=   $��2q�6O   
���   �$��	10,10,0,0q�6w   $ 10q�6�   ._�5w      �� 
�������   Update#��Z 60   $��0q�6�   
������ ��6X   �� *UpdateEmployeeCommand+6�   5x      5y      �� 5{      
���� ��$ 10��6)   $��2q�6;   
���   �$��100,20,100,0q�6d   $ 10q�6z   ._�5|      �� 
�������    ClearFields#��Z  6-   $��0q�6�   
������ ��6Z   �� *ClearFieldsCommand+6�   5}      5~      5      5�      