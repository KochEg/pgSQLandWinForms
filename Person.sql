PGDMP     "    ,                {            Person    15.2    15.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16736    Person    DATABASE     |   CREATE DATABASE "Person" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Person";
                postgres    false            �            1259    16737    Human    TABLE     �   CREATE TABLE public."Human" (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    patronymic character varying(20) NOT NULL,
    age integer NOT NULL
);
    DROP TABLE public."Human";
       public         heap    postgres    false            �          0    16737    Human 
   TABLE DATA           E   COPY public."Human" (id, name, surname, patronymic, age) FROM stdin;
    public          postgres    false    214   �       e           2606    16741    Human Human_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Human"
    ADD CONSTRAINT "Human_pkey" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public."Human" DROP CONSTRAINT "Human_pkey";
       public            postgres    false    214            �   T   x�3�0��֋M���.lB�\�q���Ȁ˄�� oÅ�pD-��Є˔�[/l���b���ai����� V�     