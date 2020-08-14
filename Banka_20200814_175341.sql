--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3
-- Dumped by pg_dump version 12rc1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: Borclandir(integer, numeric, integer, character); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."Borclandir"(id integer, deger numeric, hesapid integer, borctipi character) RETURNS void
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
    
    INSERT INTO "public"."BORCLAR" VALUES (id,HesapID,deger,BorcTipi);
    END;
$$;


ALTER FUNCTION public."Borclandir"(id integer, deger numeric, hesapid integer, borctipi character) OWNER TO postgres;

--
-- Name: FaizHesabi(integer, integer, numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."FaizHesabi"(id integer, deger integer, fm numeric) RETURNS integer
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
        RETURN deger*fm;
        
    END;
$$;


ALTER FUNCTION public."FaizHesabi"(id integer, deger integer, fm numeric) OWNER TO postgres;

--
-- Name: KrediBorclandir(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."KrediBorclandir"(id integer, krediid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
    INSERT INTO "public"."KREDI BORC" VALUES('id','OdemeID');
    END;
$$;


ALTER FUNCTION public."KrediBorclandir"(id integer, krediid integer) OWNER TO postgres;

--
-- Name: KrediCek(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."KrediCek"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$	 DECLARE
BEGIN	

OLD."ParaMiktari" = NEW."ParaMiktari";
RETURN NEW;
END; 	$$;


ALTER FUNCTION public."KrediCek"() OWNER TO postgres;

--
-- Name: OdemeBorclandir(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."OdemeBorclandir"(id integer, odemeid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
    INSERT INTO "public"."ODEME BORC" VALUES('id','OdemeID');
    END;
$$;


ALTER FUNCTION public."OdemeBorclandir"(id integer, odemeid integer) OWNER TO postgres;

--
-- Name: aktar(integer, integer, numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.aktar(base integer, target integer, deger numeric) RETURNS void
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
        UPDATE "HESAP" SET "ParaMiktari" = "ParaMiktari"-deger
          WHERE "HESAP"."Id" = base;
        UPDATE "HESAP" SET "ParaMiktari" = "ParaMiktari"+deger
          WHERE "HESAP"."Id" = target;
    END;
$$;


ALTER FUNCTION public.aktar(base integer, target integer, deger numeric) OWNER TO postgres;

--
-- Name: idArttirFunc(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."idArttirFunc"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$	 DECLARE
BEGIN	
NEW."ids" = OLD.ids+1;
RETURN NEW;
END; 	$$;


ALTER FUNCTION public."idArttirFunc"() OWNER TO postgres;

--
-- Name: ode(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ode(id integer, deger integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
    #variable_conflict use_variable
    DECLARE
        
    BEGIN
        UPDATE "HESAP" SET "ParaMiktari" = "ParaMiktari"-deger
          WHERE "HESAP"."Id" = id;
    END;
$$;


ALTER FUNCTION public.ode(id integer, deger integer) OWNER TO postgres;

--
-- Name: odemeAzaltFunc(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."odemeAzaltFunc"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$	 DECLARE
BEGIN	
OLD."ParaMiktari" = NEW."ParaMiktari";
RETURN NEW;
END; 	$$;


ALTER FUNCTION public."odemeAzaltFunc"() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: BORCLAR; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."BORCLAR" (
    "Id" integer NOT NULL,
    "HesapId" integer NOT NULL,
    "ParaMiktar" numeric,
    "BorcTipi" character(50)
);


ALTER TABLE public."BORCLAR" OWNER TO postgres;

--
-- Name: BORCLAR_HesapId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."BORCLAR_HesapId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."BORCLAR_HesapId_seq" OWNER TO postgres;

--
-- Name: BORCLAR_HesapId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."BORCLAR_HesapId_seq" OWNED BY public."BORCLAR"."HesapId";


--
-- Name: BORCLAR_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."BORCLAR_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."BORCLAR_Id_seq" OWNER TO postgres;

--
-- Name: BORCLAR_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."BORCLAR_Id_seq" OWNED BY public."BORCLAR"."Id";


--
-- Name: DOVIZ; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."DOVIZ" (
    "Id" integer NOT NULL,
    "TL" double precision,
    "Euro" double precision,
    "Dolar" double precision,
    "Sterlin" double precision
);


ALTER TABLE public."DOVIZ" OWNER TO postgres;

--
-- Name: EMIRLER; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EMIRLER" (
    "Id" integer NOT NULL,
    "BaseId" integer,
    "TargetId" integer,
    "DovizId" integer NOT NULL,
    "ParaMiktari" double precision
);


ALTER TABLE public."EMIRLER" OWNER TO postgres;

--
-- Name: EMIRLER_DovizId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."EMIRLER_DovizId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."EMIRLER_DovizId_seq" OWNER TO postgres;

--
-- Name: EMIRLER_DovizId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."EMIRLER_DovizId_seq" OWNED BY public."EMIRLER"."DovizId";


--
-- Name: FAIZ; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FAIZ" (
    "Id" integer NOT NULL,
    "FaizMiktari" double precision,
    "FaizTuruId" integer NOT NULL
);


ALTER TABLE public."FAIZ" OWNER TO postgres;

--
-- Name: FAIZ TURU; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FAIZ TURU" (
    "Id" integer NOT NULL,
    "Isim" character(250)
);


ALTER TABLE public."FAIZ TURU" OWNER TO postgres;

--
-- Name: FAIZ_FaizTuruId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."FAIZ_FaizTuruId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."FAIZ_FaizTuruId_seq" OWNER TO postgres;

--
-- Name: FAIZ_FaizTuruId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."FAIZ_FaizTuruId_seq" OWNED BY public."FAIZ"."FaizTuruId";


--
-- Name: HESAP; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HESAP" (
    "Id" integer NOT NULL,
    "DovizId" integer NOT NULL,
    "FaizId" integer NOT NULL,
    "EmirId" integer,
    "OdemeId" integer,
    "HesapAdi" character(250),
    "HesapTuruId" integer NOT NULL,
    "ParaMiktari" double precision
);


ALTER TABLE public."HESAP" OWNER TO postgres;

--
-- Name: HESAP TURU; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HESAP TURU" (
    "Id" integer NOT NULL,
    "Isim" character(250)
);


ALTER TABLE public."HESAP TURU" OWNER TO postgres;

--
-- Name: HESAP_DovizId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HESAP_DovizId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."HESAP_DovizId_seq" OWNER TO postgres;

--
-- Name: HESAP_DovizId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HESAP_DovizId_seq" OWNED BY public."HESAP"."DovizId";


--
-- Name: HESAP_EmirId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HESAP_EmirId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."HESAP_EmirId_seq" OWNER TO postgres;

--
-- Name: HESAP_EmirId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HESAP_EmirId_seq" OWNED BY public."HESAP"."EmirId";


--
-- Name: HESAP_FaizId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HESAP_FaizId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."HESAP_FaizId_seq" OWNER TO postgres;

--
-- Name: HESAP_FaizId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HESAP_FaizId_seq" OWNED BY public."HESAP"."FaizId";


--
-- Name: HESAP_HesapTuruId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HESAP_HesapTuruId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."HESAP_HesapTuruId_seq" OWNER TO postgres;

--
-- Name: HESAP_HesapTuruId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HESAP_HesapTuruId_seq" OWNED BY public."HESAP"."HesapTuruId";


--
-- Name: HESAP_OdemeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HESAP_OdemeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."HESAP_OdemeId_seq" OWNER TO postgres;

--
-- Name: HESAP_OdemeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HESAP_OdemeId_seq" OWNED BY public."HESAP"."OdemeId";


--
-- Name: KREDI; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KREDI" (
    "Id" integer NOT NULL,
    "DovizId" integer NOT NULL,
    "FaizId" integer NOT NULL,
    "KrediTipiId" integer NOT NULL,
    "SonOdemeTarihi" date DEFAULT '2024-12-31'::date,
    "ParaMiktari" double precision
);


ALTER TABLE public."KREDI" OWNER TO postgres;

--
-- Name: KREDI BORC; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KREDI BORC" (
    "Id" integer NOT NULL,
    "KrediId" integer NOT NULL
);


ALTER TABLE public."KREDI BORC" OWNER TO postgres;

--
-- Name: KREDI BORC_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KREDI BORC_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KREDI BORC_Id_seq" OWNER TO postgres;

--
-- Name: KREDI BORC_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KREDI BORC_Id_seq" OWNED BY public."KREDI BORC"."Id";


--
-- Name: KREDI BORC_KrediId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KREDI BORC_KrediId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KREDI BORC_KrediId_seq" OWNER TO postgres;

--
-- Name: KREDI BORC_KrediId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KREDI BORC_KrediId_seq" OWNED BY public."KREDI BORC"."KrediId";


--
-- Name: KREDI TIPI; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KREDI TIPI" (
    "Id" integer NOT NULL,
    "Isim" character(250)
);


ALTER TABLE public."KREDI TIPI" OWNER TO postgres;

--
-- Name: KREDI_DovizId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KREDI_DovizId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KREDI_DovizId_seq" OWNER TO postgres;

--
-- Name: KREDI_DovizId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KREDI_DovizId_seq" OWNED BY public."KREDI"."DovizId";


--
-- Name: KREDI_FaizId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KREDI_FaizId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KREDI_FaizId_seq" OWNER TO postgres;

--
-- Name: KREDI_FaizId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KREDI_FaizId_seq" OWNED BY public."KREDI"."FaizId";


--
-- Name: KREDI_KrediTipiId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KREDI_KrediTipiId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KREDI_KrediTipiId_seq" OWNER TO postgres;

--
-- Name: KREDI_KrediTipiId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KREDI_KrediTipiId_seq" OWNED BY public."KREDI"."KrediTipiId";


--
-- Name: KULLANICI; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KULLANICI" (
    "Id" integer NOT NULL,
    "HesapId" integer NOT NULL,
    "KullaniciTipId" integer NOT NULL,
    "KullaniciAdi" character(250),
    "Sifre" character(50),
    "Email" character(50),
    "TC" character(11),
    "Isim" character(250),
    "Soyisim" character(250)
);


ALTER TABLE public."KULLANICI" OWNER TO postgres;

--
-- Name: KULLANICI TIPI; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KULLANICI TIPI" (
    "Id" integer NOT NULL,
    "Isim" character(250)
);


ALTER TABLE public."KULLANICI TIPI" OWNER TO postgres;

--
-- Name: KULLANICI_HesapId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KULLANICI_HesapId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KULLANICI_HesapId_seq" OWNER TO postgres;

--
-- Name: KULLANICI_HesapId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KULLANICI_HesapId_seq" OWNED BY public."KULLANICI"."HesapId";


--
-- Name: KULLANICI_KullaniciTipId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."KULLANICI_KullaniciTipId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."KULLANICI_KullaniciTipId_seq" OWNER TO postgres;

--
-- Name: KULLANICI_KullaniciTipId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."KULLANICI_KullaniciTipId_seq" OWNED BY public."KULLANICI"."KullaniciTipId";


--
-- Name: ODEME; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ODEME" (
    "Id" integer NOT NULL,
    "OdemeTuruId" integer NOT NULL,
    "BaseId" integer,
    "TargetId" integer,
    "ParaMiktari" double precision
);


ALTER TABLE public."ODEME" OWNER TO postgres;

--
-- Name: ODEME BORC; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ODEME BORC" (
    "Id" integer NOT NULL,
    "OdemeId" integer NOT NULL
);


ALTER TABLE public."ODEME BORC" OWNER TO postgres;

--
-- Name: ODEME BORC_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ODEME BORC_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ODEME BORC_Id_seq" OWNER TO postgres;

--
-- Name: ODEME BORC_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ODEME BORC_Id_seq" OWNED BY public."ODEME BORC"."Id";


--
-- Name: ODEME BORC_OdemeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ODEME BORC_OdemeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ODEME BORC_OdemeId_seq" OWNER TO postgres;

--
-- Name: ODEME BORC_OdemeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ODEME BORC_OdemeId_seq" OWNED BY public."ODEME BORC"."OdemeId";


--
-- Name: ODEME TURU; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ODEME TURU" (
    "Id" integer NOT NULL,
    "Isim" character(250)
);


ALTER TABLE public."ODEME TURU" OWNER TO postgres;

--
-- Name: ODEME_OdemeTuruId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ODEME_OdemeTuruId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ODEME_OdemeTuruId_seq" OWNER TO postgres;

--
-- Name: ODEME_OdemeTuruId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ODEME_OdemeTuruId_seq" OWNED BY public."ODEME"."OdemeTuruId";


--
-- Name: idmaker; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.idmaker (
    ids integer
);


ALTER TABLE public.idmaker OWNER TO postgres;

--
-- Name: BORCLAR Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BORCLAR" ALTER COLUMN "Id" SET DEFAULT nextval('public."BORCLAR_Id_seq"'::regclass);


--
-- Name: BORCLAR HesapId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BORCLAR" ALTER COLUMN "HesapId" SET DEFAULT nextval('public."BORCLAR_HesapId_seq"'::regclass);


--
-- Name: EMIRLER DovizId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EMIRLER" ALTER COLUMN "DovizId" SET DEFAULT nextval('public."EMIRLER_DovizId_seq"'::regclass);


--
-- Name: FAIZ FaizTuruId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FAIZ" ALTER COLUMN "FaizTuruId" SET DEFAULT nextval('public."FAIZ_FaizTuruId_seq"'::regclass);


--
-- Name: HESAP DovizId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP" ALTER COLUMN "DovizId" SET DEFAULT nextval('public."HESAP_DovizId_seq"'::regclass);


--
-- Name: HESAP FaizId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP" ALTER COLUMN "FaizId" SET DEFAULT nextval('public."HESAP_FaizId_seq"'::regclass);


--
-- Name: HESAP EmirId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP" ALTER COLUMN "EmirId" SET DEFAULT nextval('public."HESAP_EmirId_seq"'::regclass);


--
-- Name: HESAP OdemeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP" ALTER COLUMN "OdemeId" SET DEFAULT nextval('public."HESAP_OdemeId_seq"'::regclass);


--
-- Name: HESAP HesapTuruId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP" ALTER COLUMN "HesapTuruId" SET DEFAULT nextval('public."HESAP_HesapTuruId_seq"'::regclass);


--
-- Name: KREDI DovizId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI" ALTER COLUMN "DovizId" SET DEFAULT nextval('public."KREDI_DovizId_seq"'::regclass);


--
-- Name: KREDI FaizId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI" ALTER COLUMN "FaizId" SET DEFAULT nextval('public."KREDI_FaizId_seq"'::regclass);


--
-- Name: KREDI KrediTipiId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI" ALTER COLUMN "KrediTipiId" SET DEFAULT nextval('public."KREDI_KrediTipiId_seq"'::regclass);


--
-- Name: KREDI BORC Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI BORC" ALTER COLUMN "Id" SET DEFAULT nextval('public."KREDI BORC_Id_seq"'::regclass);


--
-- Name: KREDI BORC KrediId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI BORC" ALTER COLUMN "KrediId" SET DEFAULT nextval('public."KREDI BORC_KrediId_seq"'::regclass);


--
-- Name: KULLANICI HesapId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KULLANICI" ALTER COLUMN "HesapId" SET DEFAULT nextval('public."KULLANICI_HesapId_seq"'::regclass);


--
-- Name: KULLANICI KullaniciTipId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KULLANICI" ALTER COLUMN "KullaniciTipId" SET DEFAULT nextval('public."KULLANICI_KullaniciTipId_seq"'::regclass);


--
-- Name: ODEME OdemeTuruId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME" ALTER COLUMN "OdemeTuruId" SET DEFAULT nextval('public."ODEME_OdemeTuruId_seq"'::regclass);


--
-- Name: ODEME BORC Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME BORC" ALTER COLUMN "Id" SET DEFAULT nextval('public."ODEME BORC_Id_seq"'::regclass);


--
-- Name: ODEME BORC OdemeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME BORC" ALTER COLUMN "OdemeId" SET DEFAULT nextval('public."ODEME BORC_OdemeId_seq"'::regclass);


--
-- Data for Name: BORCLAR; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."BORCLAR" VALUES (1, 100, 100, 'kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (2, 100, 100, 'odeme                                             ');
INSERT INTO public."BORCLAR" VALUES (675, 101, 400, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (1008, 101, 600, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (241, 105, 500, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (819, 105, 1000, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (826, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (490, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (920, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (982, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (399, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (1070, 101, 100, 'Kredi                                             ');
INSERT INTO public."BORCLAR" VALUES (414, 106, 10, 'Kredi                                             ');


--
-- Data for Name: DOVIZ; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."DOVIZ" VALUES (1, 1, 0.17, 0.15, 0.13);


--
-- Data for Name: EMIRLER; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."EMIRLER" VALUES (1, 1, 1, 1, 100);
INSERT INTO public."EMIRLER" VALUES (100, 100, 100, 1, 100);
INSERT INTO public."EMIRLER" VALUES (101, 101, 100, 1, 400);
INSERT INTO public."EMIRLER" VALUES (721, 101, 100, 1, 100);
INSERT INTO public."EMIRLER" VALUES (447, 102, 101, 1, 5000);
INSERT INTO public."EMIRLER" VALUES (624, 105, 101, 1, 500);
INSERT INTO public."EMIRLER" VALUES (467, 105, 100, 1, 300);
INSERT INTO public."EMIRLER" VALUES (911, 105, 100, 1, 500);
INSERT INTO public."EMIRLER" VALUES (435, 106, 105, 1, 100);
INSERT INTO public."EMIRLER" VALUES (534, 107, 100, 1, 500);


--
-- Data for Name: FAIZ; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."FAIZ" VALUES (1, 1.15, 1);


--
-- Data for Name: FAIZ TURU; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."FAIZ TURU" VALUES (1, 'Hosgeldin Faizi                                                                                                                                                                                                                                           ');


--
-- Data for Name: HESAP; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."HESAP" VALUES (102, 1, 1, 911, 389, 'Murat Hesabi                                                                                                                                                                                                                                              ', 1, 6800);
INSERT INTO public."HESAP" VALUES (103, 1, 1, 911, 389, 'Jale Hesabi                                                                                                                                                                                                                                               ', 1, 40000);
INSERT INTO public."HESAP" VALUES (104, 1, 1, 911, 389, 'Selen Hesabi                                                                                                                                                                                                                                              ', 1, 7200);
INSERT INTO public."HESAP" VALUES (105, 1, 1, 1, 389, 'Talib Hesabi                                                                                                                                                                                                                                              ', 1, 30100);
INSERT INTO public."HESAP" VALUES (101, 1, 1, 435, 389, 'Mert Hesabi                                                                                                                                                                                                                                               ', 1, 7200);
INSERT INTO public."HESAP" VALUES (100, 1, 1, 911, 389, 'akin Hesabi                                                                                                                                                                                                                                               ', 1, 3500);
INSERT INTO public."HESAP" VALUES (106, 1, 1, 534, 389, 'Abdülmuttalib  Hesabi                                                                                                                                                                                                                                     ', 1, 910);


--
-- Data for Name: HESAP TURU; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."HESAP TURU" VALUES (1, 'Vadeli Hesap                                                                                                                                                                                                                                              ');


--
-- Data for Name: KREDI; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."KREDI" VALUES (1, 1, 1, 1, '2014-12-31', 1000);


--
-- Data for Name: KREDI BORC; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."KREDI BORC" VALUES (1, 1);


--
-- Data for Name: KREDI TIPI; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."KREDI TIPI" VALUES (1, 'ihtiyac kredisi                                                                                                                                                                                                                                           ');


--
-- Data for Name: KULLANICI; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."KULLANICI" VALUES (100, 100, 1, 'akin                                                                                                                                                                                                                                                      ', '12345                                             ', 'a@k.kk                                            ', '11111111111', 'akin                                                                                                                                                                                                                                                      ', 'K                                                                                                                                                                                                                                                         ');
INSERT INTO public."KULLANICI" VALUES (101, 101, 1, 'mertg                                                                                                                                                                                                                                                     ', 'mert123                                           ', 'mert@golcu.com                                    ', '22222222222', 'Mert                                                                                                                                                                                                                                                      ', 'Golcu                                                                                                                                                                                                                                                     ');
INSERT INTO public."KULLANICI" VALUES (102, 102, 1, 'muratp                                                                                                                                                                                                                                                    ', '12345                                             ', 'mp@mp.com                                         ', '55555555555', 'Murat                                                                                                                                                                                                                                                     ', 'Pazar                                                                                                                                                                                                                                                     ');
INSERT INTO public."KULLANICI" VALUES (103, 103, 1, 'jalek                                                                                                                                                                                                                                                     ', '123456                                            ', 'jk@jk.com                                         ', '77777777777', 'Jale                                                                                                                                                                                                                                                      ', 'Kaya                                                                                                                                                                                                                                                      ');
INSERT INTO public."KULLANICI" VALUES (104, 104, 1, 'selenkk                                                                                                                                                                                                                                                   ', '123123                                            ', 'sk@sk.cm                                          ', '66666666666', 'Selen                                                                                                                                                                                                                                                     ', 'Kaplan                                                                                                                                                                                                                                                    ');
INSERT INTO public."KULLANICI" VALUES (105, 105, 1, 'talibg                                                                                                                                                                                                                                                    ', '12345                                             ', 'tg@gmail.com                                      ', '11111111111', 'Talib                                                                                                                                                                                                                                                     ', 'Guler                                                                                                                                                                                                                                                     ');
INSERT INTO public."KULLANICI" VALUES (106, 106, 1, 'abdül                                                                                                                                                                                                                                                     ', '1234                                              ', 'abdül@gmail.com                                   ', '11111111111', 'Abdülmuttalib                                                                                                                                                                                                                                             ', 'Güler                                                                                                                                                                                                                                                     ');


--
-- Data for Name: KULLANICI TIPI; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."KULLANICI TIPI" VALUES (1, 'Ogrenci                                                                                                                                                                                                                                                   ');


--
-- Data for Name: ODEME; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ODEME" VALUES (1, 1, 1, 1, 100);
INSERT INTO public."ODEME" VALUES (493, 1, 101, 1, 100);
INSERT INTO public."ODEME" VALUES (887, 1, 102, 1, 200);
INSERT INTO public."ODEME" VALUES (1034, 1, 105, 1, 200);
INSERT INTO public."ODEME" VALUES (575, 1, 105, 1, 1000);
INSERT INTO public."ODEME" VALUES (773, 1, 105, 1, 300);
INSERT INTO public."ODEME" VALUES (626, 1, 106, 1, 10500);
INSERT INTO public."ODEME" VALUES (389, 1, 107, 1, 100);


--
-- Data for Name: ODEME BORC; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ODEME BORC" VALUES (1, 1);


--
-- Data for Name: ODEME TURU; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ODEME TURU" VALUES (1, 'Fatura                                                                                                                                                                                                                                                    ');


--
-- Data for Name: idmaker; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.idmaker VALUES (107);


--
-- Name: BORCLAR_HesapId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BORCLAR_HesapId_seq"', 1, false);


--
-- Name: BORCLAR_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BORCLAR_Id_seq"', 1, false);


--
-- Name: EMIRLER_DovizId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EMIRLER_DovizId_seq"', 1, false);


--
-- Name: FAIZ_FaizTuruId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."FAIZ_FaizTuruId_seq"', 1, false);


--
-- Name: HESAP_DovizId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HESAP_DovizId_seq"', 1, false);


--
-- Name: HESAP_EmirId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HESAP_EmirId_seq"', 1, false);


--
-- Name: HESAP_FaizId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HESAP_FaizId_seq"', 1, false);


--
-- Name: HESAP_HesapTuruId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HESAP_HesapTuruId_seq"', 1, false);


--
-- Name: HESAP_OdemeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HESAP_OdemeId_seq"', 1, false);


--
-- Name: KREDI BORC_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KREDI BORC_Id_seq"', 1, false);


--
-- Name: KREDI BORC_KrediId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KREDI BORC_KrediId_seq"', 1, false);


--
-- Name: KREDI_DovizId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KREDI_DovizId_seq"', 1, false);


--
-- Name: KREDI_FaizId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KREDI_FaizId_seq"', 1, false);


--
-- Name: KREDI_KrediTipiId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KREDI_KrediTipiId_seq"', 1, false);


--
-- Name: KULLANICI_HesapId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KULLANICI_HesapId_seq"', 1, false);


--
-- Name: KULLANICI_KullaniciTipId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."KULLANICI_KullaniciTipId_seq"', 1, false);


--
-- Name: ODEME BORC_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ODEME BORC_Id_seq"', 1, false);


--
-- Name: ODEME BORC_OdemeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ODEME BORC_OdemeId_seq"', 1, false);


--
-- Name: ODEME_OdemeTuruId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ODEME_OdemeTuruId_seq"', 1, false);


--
-- Name: BORCLAR BORCLAR_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BORCLAR"
    ADD CONSTRAINT "BORCLAR_pkey" PRIMARY KEY ("Id");


--
-- Name: DOVIZ DOVIZ_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DOVIZ"
    ADD CONSTRAINT "DOVIZ_pkey" PRIMARY KEY ("Id");


--
-- Name: EMIRLER EMIRLER_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EMIRLER"
    ADD CONSTRAINT "EMIRLER_pkey" PRIMARY KEY ("Id");


--
-- Name: FAIZ TURU FAIZ TURU_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FAIZ TURU"
    ADD CONSTRAINT "FAIZ TURU_pkey" PRIMARY KEY ("Id");


--
-- Name: FAIZ FAIZ_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FAIZ"
    ADD CONSTRAINT "FAIZ_pkey" PRIMARY KEY ("Id");


--
-- Name: HESAP TURU HESAP TURU_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP TURU"
    ADD CONSTRAINT "HESAP TURU_pkey" PRIMARY KEY ("Id");


--
-- Name: HESAP HESAP_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_pkey" PRIMARY KEY ("Id");


--
-- Name: KREDI BORC KREDI BORC_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI BORC"
    ADD CONSTRAINT "KREDI BORC_pkey" PRIMARY KEY ("Id");


--
-- Name: KREDI TIPI KREDI TIPI_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI TIPI"
    ADD CONSTRAINT "KREDI TIPI_pkey" PRIMARY KEY ("Id");


--
-- Name: KREDI KREDI_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI"
    ADD CONSTRAINT "KREDI_pkey" PRIMARY KEY ("Id");


--
-- Name: KULLANICI TIPI KULLANICI TIPI_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KULLANICI TIPI"
    ADD CONSTRAINT "KULLANICI TIPI_pkey" PRIMARY KEY ("Id");


--
-- Name: KULLANICI KULLANICI_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KULLANICI"
    ADD CONSTRAINT "KULLANICI_pkey" PRIMARY KEY ("Id");


--
-- Name: ODEME BORC ODEME BORC_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME BORC"
    ADD CONSTRAINT "ODEME BORC_pkey" PRIMARY KEY ("Id");


--
-- Name: ODEME TURU ODEME TURU_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME TURU"
    ADD CONSTRAINT "ODEME TURU_pkey" PRIMARY KEY ("Id");


--
-- Name: ODEME ODEME_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME"
    ADD CONSTRAINT "ODEME_pkey" PRIMARY KEY ("Id");


--
-- Name: HESAP arttirma; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER arttirma BEFORE UPDATE ON public."HESAP" FOR EACH ROW EXECUTE FUNCTION public."KrediCek"();


--
-- Name: HESAP azaltma; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER azaltma BEFORE UPDATE ON public."HESAP" FOR EACH ROW EXECUTE FUNCTION public."odemeAzaltFunc"();


--
-- Name: idmaker idarttir; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER idarttir BEFORE UPDATE ON public.idmaker FOR EACH ROW EXECUTE FUNCTION public."idArttirFunc"();


--
-- Name: BORCLAR BORCLAR_HesapId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BORCLAR"
    ADD CONSTRAINT "BORCLAR_HesapId_fkey" FOREIGN KEY ("HesapId") REFERENCES public."HESAP"("Id");


--
-- Name: EMIRLER EMIRLER_DovizId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EMIRLER"
    ADD CONSTRAINT "EMIRLER_DovizId_fkey" FOREIGN KEY ("DovizId") REFERENCES public."DOVIZ"("Id");


--
-- Name: FAIZ FAIZ_FaizTuruId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FAIZ"
    ADD CONSTRAINT "FAIZ_FaizTuruId_fkey" FOREIGN KEY ("FaizTuruId") REFERENCES public."FAIZ TURU"("Id");


--
-- Name: HESAP HESAP_DovizId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_DovizId_fkey" FOREIGN KEY ("DovizId") REFERENCES public."DOVIZ"("Id");


--
-- Name: HESAP HESAP_EmirId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_EmirId_fkey" FOREIGN KEY ("EmirId") REFERENCES public."EMIRLER"("Id");


--
-- Name: HESAP HESAP_FaizId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_FaizId_fkey" FOREIGN KEY ("FaizId") REFERENCES public."FAIZ"("Id");


--
-- Name: HESAP HESAP_HesapTuruId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_HesapTuruId_fkey" FOREIGN KEY ("HesapTuruId") REFERENCES public."HESAP TURU"("Id");


--
-- Name: HESAP HESAP_OdemeId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HESAP"
    ADD CONSTRAINT "HESAP_OdemeId_fkey" FOREIGN KEY ("OdemeId") REFERENCES public."ODEME"("Id");


--
-- Name: KREDI BORC KREDI BORC_KrediId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI BORC"
    ADD CONSTRAINT "KREDI BORC_KrediId_fkey" FOREIGN KEY ("KrediId") REFERENCES public."KREDI"("Id");


--
-- Name: KREDI KREDI_DovizId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI"
    ADD CONSTRAINT "KREDI_DovizId_fkey" FOREIGN KEY ("DovizId") REFERENCES public."DOVIZ"("Id");


--
-- Name: KREDI KREDI_FaizId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI"
    ADD CONSTRAINT "KREDI_FaizId_fkey" FOREIGN KEY ("FaizId") REFERENCES public."FAIZ"("Id");


--
-- Name: KREDI KREDI_KrediTipiId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KREDI"
    ADD CONSTRAINT "KREDI_KrediTipiId_fkey" FOREIGN KEY ("KrediTipiId") REFERENCES public."KREDI TIPI"("Id");


--
-- Name: KULLANICI KULLANICI_KullaniciTipId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KULLANICI"
    ADD CONSTRAINT "KULLANICI_KullaniciTipId_fkey" FOREIGN KEY ("KullaniciTipId") REFERENCES public."KULLANICI TIPI"("Id");


--
-- Name: ODEME BORC ODEME BORC_OdemeId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME BORC"
    ADD CONSTRAINT "ODEME BORC_OdemeId_fkey" FOREIGN KEY ("OdemeId") REFERENCES public."ODEME"("Id");


--
-- Name: ODEME ODEME_OdemeTuruId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ODEME"
    ADD CONSTRAINT "ODEME_OdemeTuruId_fkey" FOREIGN KEY ("OdemeTuruId") REFERENCES public."ODEME TURU"("Id");


--
-- PostgreSQL database dump complete
--

