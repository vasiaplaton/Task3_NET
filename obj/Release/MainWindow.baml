   M S B A M L   `   `   `  ���� 	  Task3    Task3.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  My App��$	��650��$	��800�� � 	Resources  �� 
TargetType �� Property �� Value��%  '��       '�� �     '�� �     '�� `    �� " ��.���  � �� �#FF8C00��  � ��
 �������  � ��$ 15q���  � ��$ 10q���  � ��$ 16(��� " ��.���  � �� �#2E8B57��  � ��$ 18(���  � ��$ 10q��� " ��.���  � �� �	#FFD3D3D3��  � �� �#2E8B57��  � ��$ 2q���  � ��$ 10q���  � ��$ 10q��� " ��.���  � �� �	#FFD3D3D3��  � �� �#2E8B57��  � ��$ 2q���  � ��$ 10q���  � ��$ 10q�.��� ���	#FFF0F8FF � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $��* ��� $
��Auto �.+�� $��0��$��0�� �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.+��� $*��$Загруженная сборка:��$
��Bold"��� $	��5,0q����� *AssemblyPath+�� $��1��$%��Загрузить сборку������ *LoadAssemblyCommand+�� $��2��$$��Выбранный класс:��$
��Bold"�$��	0,20,0,10q��� $��2��$��
0,72,0,284q����� *EntityNames+ �� SelectedItem �� *SelectedEntityName+� $��0��$��1�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.+��� $2��,Параметры конструктора:��$
��Bold"��� $	��150������ *ConstructorParameters+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��5q����� *Name+�� $	��100��$��5q����� *Value+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��1��.+��� $"��Список методов:��$
��Bold"��� $	��240��$	��388������ *	Methods+ �� *SelectedMethod+�� $��1��$��2��$ 
Horizontal=�$��Center=�$��Center=�.+��� $#��Выполнить метод������ *ExecuteMethodCommand+�� $;��5Результат выполнения метода:��$
��Bold"�$��20,0,0,0q���  �� 
IsReadOnly . $��68��$	��268��$��10q����� *MethodResult+$	 OneWay=�