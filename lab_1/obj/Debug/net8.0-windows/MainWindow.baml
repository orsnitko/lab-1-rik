   M S B A M L   `   `   `  ����@  <lab_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab_1lab_1  5   	       lab_1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:lab_1     5   	   -   5        $��tittle��5	   j     � Title$)  #Текстовий редактор��6	   $	��432��6$   $	��870��61   $��18(�6=   $	��430��6K   $	��300��6Z    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value   SaveAsStyle	 �� BasedOn��%�  '��       &	  �    7��'��     '�� �    �� 5   
   " ��6   .�5      ��  � ��$ 35��6'   �� 5       � ��$ 70��6&   �� 5       � ��$ Verdana)�6+   �� 5       � ��$ 12(�6)   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$ Arrow��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#9B417D6?   �� 5    "    � ��
 �����6?   �� 5!   "    �@�Cursor$
 Hand��6;   5"      5$      5&      5'      �� 5+   
   " ��6$   8	   .�5,      ��  � ��$ 80��6&   5-      �� 50   
   " ��6   .�51      ��  � ��$ 16(�6)   �� 52       � ��$ Consolas)�6+   �� 53       � ��$ 5q�6(   �� 54       � ��$ 1q�60   �� 55       �@��AcceptsReturn$
 True��6.   �� 56       �@��TextWrapping$
 Wrap=�6-   �� 57      # �@��VerticalScrollBarVisibility$
 Auto=�6<   �� 58      % �@��HorizontalScrollBarVisibility$
 Auto=�6>   59      �� 5:   
   " ��6   5<      5=      .��5?      � 
 � RowDefinitions
 5@   
   �� 5A      $
��Auto �6   �� 5C      $��* �6   .+�5H   
   ��  �� Orientation$ 
Horizontal=�6   ���#FAE8FF$��0��6C   .+�5I      �� -   5        $��Створити��5I      6(   �� 5J      -   5        $��Відкрити��5J      6(   �� 5K      -   5        $��Зберегти��5K      6(   �� 5L      -   5        $��Зберегти як��5L      #��[  6+   6P   �� 5M      -   5        $��Закрити��5M      6'   5N      �� 5Q   
   -   5        $��	text_box1��5Q      $��1��6#   ���#9B417D6F   5R      5S      